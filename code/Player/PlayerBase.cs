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

		base.Respawn();
	}

	public override void Simulate( Client cl )
	{
		DoInputControls();

		TickPlayerUse();

		if ( !CanMove ) return;

		if ( LifeState == LifeState.Dead && CurrentTeam == TeamEnum.Chimera )
			return;

		base.Simulate( cl );
		SimulateActiveChild( cl, ActiveChild );
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

				Log.Info( tr.HitboxIndex );

				if ( tr.Entity is PlayerBase player )
					if ( player.CurrentTeam == TeamEnum.Chimera && player.ActiveChimera )
						//Button bone
						if ( tr.HitboxIndex == 0 )
						{
							player.BackButtonPressed();
							Rankup();
						}
			}
		} 
		else if ( CurrentTeam == TeamEnum.Chimera && ActiveChimera )
		{
			if ( Input.Pressed( InputButton.Attack1 ) && CanBite() )
				Bite();

			if ( !CanMove && timeLastBite > 1.25f )
				CanMove = true;
		}
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
		lastPos = Position;

		Sound.FromEntity( "pig_die", this);

		BecomeRagdollOnClient(Velocity, 0, Position, 0, 0);

		base.TakeDamage( info );
	}

	public override void OnKilled()
	{
		base.OnKilled();

		if ( CurrentTeam == TeamEnum.Pigmask )
		{
			SpawnAsGhostAtLocation( lastPos );
			ResetRank();
		}

		Event.Run( "evnt_roundstatus" );

		EnableDrawing = false;
	}
}
