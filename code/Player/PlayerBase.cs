using Sandbox;
using System;
using System.Linq;

public partial class PlayerBase : Sandbox.Player
{
	private bool IsTaunting = false;
	private bool CanMove = true;

	private Vector3 lastPos;

	private DamageInfo lastDamage;

	private Sound currentSound;

	public enum TeamEnum
	{
		Spectator,
		Pigmask,
		Chimera
	}

	public TeamEnum CurrentTeam;

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

		StopSoundOnClient( To.Single( this ) );
		CanMove = true;

		base.Respawn();
	}

	public override void Simulate( Client cl )
	{
		DoInputControls();
		TickPlayerUse();

		if ( !CanMove ) return;
		if ( LifeState == LifeState.Dead && CurrentTeam == TeamEnum.Chimera )
			return;

		var controller = GetActiveController();
		controller?.Simulate( cl, this, GetActiveAnimator() );
	}

	private void DoInputControls()
	{
		//Pigmask Controls
		if ( CurrentTeam == TeamEnum.Pigmask )
		{
			//G Key - Taunt
			if ( Input.Pressed( InputButton.Drop ) && !IsTaunting )
				Taunt();
			else if ( IsTaunting && timeSinceTaunt > 2.5f )
			{
				CameraMode = new FirstPersonCamera();
				IsTaunting = false;
				CanMove = true;
			}

			//Use key or Mouse 1 on Chimera's button
			if ( Input.Pressed( InputButton.Use ) || Input.Pressed( InputButton.Attack1 ) )
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

	[ClientRpc]
	private void PlayAnimationsOnClient(string anim, bool active)
	{
		SetAnimParameter( anim, active );
	}

	[ClientRpc]
	private void PlaySoundToClient(string soundPath)
	{
		currentSound = Sound.FromScreen( soundPath );
	}

	[ClientRpc]
	private void StopSoundOnClient()
	{
		currentSound.Stop();
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
			SpawnAsGhostAtLocation( lastPos );
			ResetRank();
		}

		Event.Run( "evnt_roundstatus" );

		EnableDrawing = false;
	}
}
