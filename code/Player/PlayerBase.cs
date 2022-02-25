using Sandbox;
using System;
using System.Linq;

public partial class PlayerBase : Sandbox.Player
{
	private bool IsTaunting = false;
	private bool CanMove = true;

	private Vector3 lastPos;

	private DamageInfo lastDamage;

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

		base.Respawn();
	}

	public override void Simulate( Client cl )
	{
		if(IsServer)
			DoInputControls();

		TickPlayerUse();

		if ( !CanMove ) return;

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
		} 
		else if ( CurrentTeam == TeamEnum.Chimera )
		{
			if ( Input.Pressed( InputButton.Attack1 ) && CanBite() )
				Bite();
		}

		//Use key on Chimera's button
		if ( Input.Pressed( InputButton.Use ) )
		{
			var tr = Trace.Ray( EyePosition, EyePosition + EyeRotation.Forward * 125 )
			.Size( 2 )
			.Ignore( this )
			.Run();

			DebugOverlay.Line( tr.StartPosition, tr.EndPosition, 5f );

			if ( tr.Entity is PlayerBase player )
			{
				if ( player.CurrentTeam == TeamEnum.Chimera )
				{
					Log.Info( tr.HitboxIndex );
				}
			}
		}

	}

	[ClientRpc]
	private void PlaySoundToClient(string soundPath)
	{
		PlaySound( soundPath );
	}

	public override void TakeDamage( DamageInfo info )
	{
		lastPos = Position;

		PlaySound( "pig_die" );

		BecomeRagdollOnClient( Velocity, lastDamage.Flags, lastDamage.Position, lastDamage.Force, GetHitboxBone( lastDamage.HitboxIndex ) );

		base.TakeDamage( info );
	}

	public override void OnKilled()
	{
		base.OnKilled();

		SpawnAsGhostAtLocation( lastPos );
		ResetRank();

		Event.Run( "evnt_roundstatus" );

		EnableDrawing = false;
	}
}
