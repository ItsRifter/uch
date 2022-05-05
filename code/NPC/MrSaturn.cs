using Sandbox;
using System;
using System.Linq;

public partial class MrSaturn : AnimEntity
{
	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/npc/mr_saturn.vmdl" );

		CollisionGroup = CollisionGroup.Player;
		SetupPhysicsFromCapsule( PhysicsMotionType.Keyframed, Capsule.FromHeightAndRadius( 4, 8 ) );

		EnableHitboxes = true;
		PhysicsEnabled = true;

		var spawnpoints = Entity.All.OfType<MrSaturnSpawn>();
		var randomSpawnPoint = spawnpoints.OrderBy( x => Guid.NewGuid() ).FirstOrDefault();

		if ( randomSpawnPoint == null )
		{
			Log.Error( "THIS MAP ISN'T SUPPORTED FOR ULTIMATE CHIMERA HUNT" );
			return;
		}

		Position = randomSpawnPoint.Position;
	}
}
