using Sandbox;
using Sandbox.UI;
using System;
using System.Linq;
public partial class PlayerBase : Sandbox.Player
{
	private bool isTaunting = false;
	public bool shouldRankUp = false;

	private TimeSince timeLastSprinted;

	[Net] public bool DidDisableChimera { get; set; }

	[Net]
	public bool CanMove { get; private set; } = true;

	private Vector3 deathPosition;
	public DamageInfo dmgInfo;

	private MrSaturn holdingSaturn;
	private MrSaturnThrowable holdingThrownSaturn;

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

		base.Spawn();
	}

	public override void Respawn()
	{
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		DidDisableChimera = false;
		CanMove = true;

		holdingSaturn?.Delete();
		holdingThrownSaturn?.Delete();
		hasSaturn = false;

		if (shouldRankUp)
		{
			Rankup();
			shouldRankUp = false;
		}

		base.Respawn();

		if ( CurrentTeam == TeamEnum.Spectator )
		{
			if ( Rand.Int( 1, 100 ) >= 75)
				SpawnAsFancyGhostAtLocation();
			else
				SpawnAsGhostAtLocation();
		}
	}

	public override void FrameSimulate( Client cl )
	{
		if ( !CanMove )
			return;

		EyeRotation = Rotation;

		base.FrameSimulate( cl );
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
					SetAnimParameter( "b_scared", false );
				}

				if(hasSaturn)
				{
					var droppedSaturn = new MrSaturn();
					droppedSaturn.Position = Position + Vector3.Up * 10;

					holdingSaturn?.Delete();
					holdingThrownSaturn?.Delete();

					hasSaturn = false;

				}
				return;
			}

			if(isWhipped)
			{
				if ( timeLastWhipped > 2.25f )
					isWhipped = false;
				
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
			if ( Input.Pressed( InputButton.Use ) || Input.Pressed( InputButton.Attack1 ) && !IsScared && !isWhipped)
			{
				var tr = Trace.Ray( EyePosition, EyePosition + EyeRotation.Forward * 90 )
				.Size( 2 )
				.Ignore( this )
				.UseHitboxes( true )
				.Run();

				if ( hasSaturn && IsServer )
				{
					hasSaturn = false;

					holdingSaturn?.Delete();
					holdingThrownSaturn?.Delete();

					using ( Prediction.Off() )
					{
						Sound.FromEntity( "saturn_throw", this );

						var saturnThrowable = new MrSaturnThrowable();
						saturnThrowable.Position = tr.EndPosition;
						saturnThrowable.Rotation = EyeRotation;
						saturnThrowable.Owner = this;
					}
					return;
				}

				if ( tr.Entity is BreakableWall wall )
				{
					DamageInfo dmgInfo = new DamageInfo();
					dmgInfo.Attacker = this;
					dmgInfo.Damage = 1;

					wall.TakeDamage( dmgInfo );
					return;
				}

				if ( tr.Entity is MrSaturn saturn && IsServer )
				{
					using ( Prediction.Off() )
						Sound.FromEntity( "saturn_pickup", this );

					hasSaturn = true;

					saturn.Transform = (Transform)GetAttachment( "saturn_hold" );
					saturn.SetParent(this, GetBoneIndex( "bip01_r_hand" ) );
					saturn.EnableHideInFirstPerson = true;
					holdingSaturn = saturn;

					return;
				}
				else if ( tr.Entity is MrSaturnThrowable saturnThrown && IsServer )
				{
					using(Prediction.Off())
						Sound.FromEntity( "saturn_pickup", this );

					hasSaturn = true;

					saturnThrown.Transform = (Transform)GetAttachment( "saturn_hold" );
					saturnThrown.SetParent( this, GetBoneIndex( "bip01_r_hand" ) );
					saturnThrown.EnableHideInFirstPerson = true;
					holdingThrownSaturn = saturnThrown;
					return;
				}

				if ( tr.Entity is PlayerBase player )
					if ( player.CurrentTeam == TeamEnum.Chimera && player.ActiveChimera )
						//Button bone
						if ( tr.HitboxIndex == 0 )
						{
							player.BackButtonPressed(this);

							DidDisableChimera = true;
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

			//Shift Key - Sprinting
			if ( Input.Down( InputButton.Run ) && ChimeraStaminaAmount > 0.0f)
			{
				timeLastSprinted = 0;
				ChimeraStaminaAmount -= 1.0f;
			}

			//Reload - Tailwhip
			if ( Input.Pressed( InputButton.Reload ) )
				Tailwhip();

			if ( timeLastBite > 1.25f && timeLastRoar > 2.75f )
				CanMove = true;
			else return;

			if(timeLastRoar > 6.5f && ChimeraRoarAmount < 50.0f)
			{
				ChimeraRoarAmount += 0.25f;
			}

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

			if( timeLastTailwhip > 3 && ChimeraTailStaminaAmount < 100.0f)
			{
				ChimeraTailStaminaAmount += 1.0f;

				if ( ChimeraTailStaminaAmount > 100.0 )
					ChimeraTailStaminaAmount = 100.0f;
			}

			if ( Input.Pressed( InputButton.Attack2 ) && GroundEntity != null )
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

	[ClientRpc]
	public virtual void OnKilledMessage( long leftid, string left, long rightid, string right, string method )
	{
		UCHKillFeed.Current?.AddEntry( leftid, left, rightid, right, method );
	}

	public override void OnKilled()
	{
		base.OnKilled();

		Host.AssertServer();

		deathPosition = Position;
		Game.Current.CheckRoundStatus();

		CameraMode = new SpectateRagdollCamera();

		if ( CurrentTeam == TeamEnum.Pigmask && dmgInfo.Attacker.IsValid )
		{
			EnableDrawing = false;
			CurrentTeam = TeamEnum.Spectator;
			Sound.FromEntity( "pig_die", this );
			Game.Current.PlaySoundToClient( To.Everyone, "pig_killed" );
			IsScared = false;
			isWhipped = false;

			OnKilledMessage( dmgInfo.Attacker.Client.Id, dmgInfo.Attacker.Client.Name, Client.PlayerId, Client.Name, "chimera" );
		}
		else if (CurrentTeam == TeamEnum.Pigmask)
		{
			EnableDrawing = false;
			CurrentTeam = TeamEnum.Spectator;
			Sound.FromEntity( "pig_die", this );
			Game.Current.PlaySoundToClient( To.Everyone, "pig_killed" );
			IsScared = false;
			isWhipped = false;

			OnKilledMessage( 0, "", Client.PlayerId, Client.Name, "suicide" );
		}
	}
}
