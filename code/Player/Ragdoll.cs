using Sandbox;

partial class PlayerBase
{
	[ClientRpc]
	private void BecomeChimeraRagdollClient( Vector3 velocity )
	{
		EnableDrawing = false;
		var ent = new ModelEntity();
		ent.Position = Position;
		ent.Rotation = Rotation;
		ent.Scale = Scale;
		ent.MoveType = MoveType.Physics;
		ent.UsePhysicsCollision = true;
		ent.CollisionGroup = CollisionGroup.Debris;
		ent.SetModel( "models/player/chimera/chimera_ragdoll.vmdl" );
		ent.CopyBonesFrom( this );
		ent.CopyBodyGroups( this );
		ent.CopyMaterialGroup( this );

		ent.EnableHitboxes = false;
		ent.EnableAllCollisions = true;
		ent.SurroundingBoundsMode = SurroundingBoundsType.Physics;
		ent.RenderColor = RenderColor;

		ent.SetInteractsAs( CollisionLayer.Debris );
		ent.SetInteractsWith( CollisionLayer.WORLD_GEOMETRY );
		ent.SetInteractsExclude( CollisionLayer.Player | CollisionLayer.Debris );

		Corpse = ent;

		ent.DeleteAsync( 6.0f );
	}

	[ClientRpc]
	private void BecomeRagdollOnClient( Vector3 velocity, Vector3 eyePosChimera )
	{
		var ent = new ModelEntity();
		ent.Position = Position;
		ent.Rotation = Rotation;
		ent.Scale = Scale;
		ent.MoveType = MoveType.Physics;
		ent.UsePhysicsCollision = true;
		ent.CollisionGroup = CollisionGroup.Debris;
		ent.SetModel( "models/player/pigmask/pigmask_ragdoll.vmdl" );
		ent.CopyBonesFrom( this );
		ent.CopyBodyGroups( this );
		ent.CopyMaterialGroup( this );

		ent.EnableHitboxes = false;
		ent.EnableAllCollisions = true;
		ent.SurroundingBoundsMode = SurroundingBoundsType.Physics;
		ent.RenderColor = RenderColor;
	
		ent.SetInteractsAs( CollisionLayer.Debris );
		ent.SetInteractsWith( CollisionLayer.WORLD_GEOMETRY );
		ent.SetInteractsExclude( CollisionLayer.Player | CollisionLayer.Debris );

		Corpse = ent;

		ent.DeleteAsync( 6.0f );
	}
}
