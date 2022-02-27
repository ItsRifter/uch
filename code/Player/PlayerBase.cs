using Sandbox;
using System;
using System.Linq;

public partial class PlayerBase : Sandbox.Player
{
	private bool IsTaunting = false;

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

		CurrentTeam = TeamEnum.Unspecified;

		EnableAllCollisions = true;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		CanMove = true;

		if(CurrentTeam == TeamEnum.Spectator)
			EnableAllCollisions = false;

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
		DoInputControls();
		TickPlayerUse();

		UsePhysicsCollision = false;

		if ( !CanMove && IsServer )	return;
	
		if ( LifeState == LifeState.Dead && CurrentTeam == TeamEnum.Chimera )
			return;

		base.Simulate(cl);
	}

	private void DoInputControls()
	{
		//Pigmask Controls
		if ( CurrentTeam == TeamEnum.Pigmask )
		{
			//G Key - Taunt
			if ( Input.Pressed( InputButton.Drop ) && !IsTaunting && GroundEntity != null )
				Taunt();
			else if ( IsTaunting && timeSinceTaunt > 2.5f )
			{
				CameraMode = new FirstPersonCamera();
				IsTaunting = false;
				CanMove = true;
			}

			//Shift Key - Sprinting
			if ( Input.Down( InputButton.Run ) && StaminaAmount > 0.0f )
			{
				timeLastSprinted = 0;
				StaminaAmount -= 2.5f;
			}
			else if ( timeLastSprinted >= 5 && StaminaAmount < 100.0f )
			{
				StaminaAmount += 0.5f;
			}

			//Use key or Mouse 1 on Chimera's button
			if ( Input.Pressed( InputButton.Use ) || Input.Pressed( InputButton.Attack1 ) )
			{
				if ( Game.Current.CurrentRoundStatus != Game.RoundEnum.Active ) return;

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
							Rankup();
							using ( Prediction.Off() )
								Sound.FromEntity("button_press", this);
						}
			}
		}
		//Chimera Controls
		else if ( CurrentTeam == TeamEnum.Chimera && ActiveChimera )
		{
			if ( Input.Pressed( InputButton.Attack1 ) && CanBite() )
				Bite();

			if ( !CanMove && timeLastBite > 1.25f )
				CanMove = true;
		}
	}

	public override void TakeDamage( DamageInfo info )
	{
		base.TakeDamage( info );
	}

	public override void OnKilled()
	{
		base.OnKilled();

		lastPos = Position;
		BecomeRagdollOnClient( Velocity, 0, Position, new Vector3(25, 0), 0 );

		if ( CurrentTeam == TeamEnum.Pigmask )
		{
			Sound.FromEntity( "pig_die", this );
			ResetRank();

			if ( Client.PlayerId == 76561197972285500 )
				SpawnAsFancyGhost();

			SpawnAsGhostAtLocation( lastPos );

			Game.Current.PlaySoundToClient( To.Everyone, "pig_killed" );
		}

		Event.Run( "evnt_roundstatus" );
	}
}
