using Sandbox;
using System;
using System.Linq;

public partial class PlayerBase : Sandbox.Player
{
	private bool isTaunting = false;
	private bool shouldRankUp = false;
	private bool hasDied = false;

	private TimeSince timeLastSprinted;

	[Net]
	public bool CanMove { get; private set; } = true;

	private Vector3 lastPos;

	private DamageInfo lastDamage;

	[Net]
	public float StaminaAmount { get; private set; } = 100.0f;

	public enum TeamEnum
	{
		Unspecified,
		Spectator,
		Pigmask,
		Chimera
	}

	[Net, Change( nameof( OnTeamChange ) )]
	public TeamEnum CurrentTeam { get; private set; } = TeamEnum.Spectator;

	public void OnTeamChange( TeamEnum oldTeam, TeamEnum newTeam )
	{
	}

	public void InitialSpawn()
	{
		SpawnAsGhost();

		Animator = new UCHAnimator();
		CameraMode = new FirstPersonCamera();

		base.Respawn();
	}

	public override void Respawn()
	{

		EnableAllCollisions = true;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;
		
		if(CurrentTeam == TeamEnum.Spectator)
			SpawnAsGhostAtLocation( lastPos );

		CanMove = true;

		StaminaAmount = StaminaMaxAmount;

		if (shouldRankUp)
		{
			Rankup();
			shouldRankUp = false;
		}

		base.Respawn();
	}

	public override void BuildInput( InputBuilder inputBuilder )
	{
		if ( !CanMove )
			return;

		base.BuildInput( inputBuilder );
	}

	public override void Simulate( Client cl )
	{
		if ( Game.Current.CurrentRoundStatus == Game.RoundEnum.Active )
			DoInputControls();
		else
			CanMove = true;

		TickPlayerUse();

		if ( CurrentTeam == TeamEnum.Pigmask )
			MakeSnorting();

		if ( !CanMove && IsServer )	return;
	
		if ( LifeState == LifeState.Dead && CurrentTeam == TeamEnum.Chimera )
			return;

		base.Simulate(cl);
	}

	private void MakeSnorting()
	{
		if ( timeRandomSnort - Time.Now > 0.0f )
			return;

		Sound.FromEntity( "snort", this );

		timeRandomSnort = Rand.Float(5.0f, 15.0f) + Time.Now;
	}

	private void DoInputControls()
	{
		//Pigmask Controls
		if ( CurrentTeam == TeamEnum.Pigmask )
		{
			if ( IsScared )
			{
				SetAnimParameter( "b_scared", true );
				if ( timeLastScared > 7.25f )
				{
					IsScared = false;
					CameraMode = new UCHCamera();
					timeLastSprinted = 1.5f;
					StaminaAmount = 0.0f;
				}
				return;
			}

			//G Key - Taunt
			if ( Input.Pressed( InputButton.Drop ) && !isTaunting && GroundEntity != null )
				Taunt();
			else if ( isTaunting && timeSinceTaunt > 2.5f )
			{
				CameraMode = new FirstPersonCamera();
				isTaunting = false;
				CanMove = true;
			}

			//Shift Key - Sprinting
			if ( Input.Down( InputButton.Run ) && StaminaAmount > 0.0f && !staminaExhausted )
			{
				timeLastSprinted = 0;
				StaminaAmount -= 2.5f;
			}
			else if ( timeLastSprinted >= 5 && StaminaAmount < StaminaMaxAmount )
			{
				StaminaAmount += 0.5f;
			}

			if ( StaminaAmount <= 0.0f )
				staminaExhausted = true;
			else if ( StaminaAmount >= StaminaMaxAmount )
				staminaExhausted = false;

			//Use key or Mouse 1 on Chimera's button
			if ( Input.Pressed( InputButton.Use ) || Input.Pressed( InputButton.Attack1 ) && !IsScared )
			{
				var tr = Trace.Ray( EyePosition, EyePosition + EyeRotation.Forward * 90 )
				.Size( 2 )
				.Ignore( this )
				.UseHitboxes( true )
				.Run();

				if ( tr.Entity is PlayerBase player )
					if ( player.CurrentTeam == TeamEnum.Chimera && player.ActiveChimera )
						//Button bone
						if ( tr.HitboxIndex == 0 )
						{
							player.BackButtonPressed();

							shouldRankUp = true;

							using ( Prediction.Off() )
								Sound.FromEntity("button_press", this);
						}
			}
		}
		//Chimera Controls
		else if ( CurrentTeam == TeamEnum.Chimera && ActiveChimera )
		{
			if ( timeLastRoar < 2.75f )
			{
				var nearestPigmasks = FindInSphere( Position, 356 );

				foreach ( var pigmask in nearestPigmasks )
				{
					if ( pigmask is PlayerBase player && pigmask != this && player.IsScared == false )
					{
						player.CameraMode = new ThirdPersonCamera();
						player.timeLastScared = 0;
						player.IsScared = true;

						Sound.FromEntity( "squeal", player );
					}
				}
			}

			if ( timeLastBite > 1.25f && timeLastRoar > 2.75f )
				CanMove = true;
			else return;


			if ( Input.Pressed( InputButton.Attack1 ) && CanBite() )
				Bite();

			if ( Input.Pressed( InputButton.Jump ) && GroundEntity == null )
			{
				FlyUpwards();
			}
			else if ( Input.Pressed( InputButton.Jump ) && GroundEntity != null )
			{
				timeLastFlew = 0.0f;
			}

			if ( timeLastSprinted >= 5 && ChimeraStaminaAmount < 200.0f )
			{
				ChimeraStaminaAmount += 1.5f;

				if ( ChimeraStaminaAmount > 200.0f )
					ChimeraStaminaAmount = 200.0f;
			}

			if ( Input.Pressed( InputButton.Attack2 ) && ChimeraStaminaAmount >= 199.0f && GroundEntity != null )
				Roar();
		}
	}

	public void ResetPlayers()
	{
		CurrentTeam = TeamEnum.Unspecified;
	}

	public override void TakeDamage( DamageInfo info )
	{
		base.TakeDamage( info );
	}

	public override void OnKilled()
	{
		base.OnKilled();

		lastPos = Position;
		Game.Current.CheckRoundStatus();

		if ( CurrentTeam == TeamEnum.Pigmask )
		{
			EnableDrawing = false;
			CurrentTeam = TeamEnum.Spectator;
			Sound.FromEntity( "pig_die", this );
			Game.Current.PlaySoundToClient( To.Everyone, "pig_killed" );
			IsScared = false;
		}
	}
}
