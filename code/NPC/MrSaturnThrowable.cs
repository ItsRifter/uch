using Sandbox;
using System;
using System.Linq;

public partial class MrSaturnThrowable : AnimEntity
{
	float Speed;
	private bool hitWorld;

	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/npc/mr_saturn.vmdl" );

		CollisionGroup = CollisionGroup.Player;

		SetupPhysicsFromCapsule( PhysicsMotionType.Keyframed, Capsule.FromHeightAndRadius( 4, 8 ) );

		EnableHitboxes = true;
		PhysicsEnabled = true;

		Speed = Rand.Float( 100, 300 );
	}

	[Event.Tick.Server]
	public virtual void Tick()
	{
		if ( !IsServer )
			return;

		if ( hitWorld )
			return;

		float Speed = 500.0f;
		var velocity = Owner.EyeRotation.Forward * Speed;

		var start = Position;
		var end = start + velocity * Time.Delta;

		var tr = Trace.Ray( start, end )
				.UseHitboxes()
				.Ignore( Owner )
				.Ignore( this )
				.Size( 4.0f )
				.Run();

		if ( tr.Hit )
		{

			hitWorld = true;
			Position = tr.EndPosition + Rotation.Forward * -1;

			if ( tr.Entity.IsValid() && tr.Entity is PlayerBase chimera && Owner is PlayerBase player)
			{
				if( chimera.ActiveChimera )
				{
					chimera.BackButtonPressed(player);
					player.DidDisableChimera = true;
					player.shouldRankUp = true;

					player.PlaySound( "saturn_kill_win" );
				}
			}

			Owner = null;

			velocity = default;
		}
		else
		{
			Position = end;
		}
	}
}
