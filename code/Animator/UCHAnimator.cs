using System;
using Sandbox;

public class UCHAnimator : PawnAnimator
{
	TimeSince TimeSinceFootShuffle = 60;

	float duck;

	public override void Simulate()
	{
		var player = Pawn as PlayerBase;
		var idealRotation = Rotation.LookAt( Input.Rotation.Forward.WithZ( 0 ), Vector3.Up );

		DoRotation( idealRotation );
		DoWalk();

		//SetAnimParameter( "b_grounded", GroundEntity != null );

		Vector3 aimPos = Pawn.EyePosition + Input.Rotation.Forward * 200;
		Vector3 lookPos = aimPos;

		//SetLookAt( "aim_head", lookPos );
		//SetLookAt( "aim_body", aimPos );

		if ( player != null && player.ActiveChild is BaseCarriable carry )
		{
			carry.SimulateAnimator( this );
		}

	}

	public virtual void DoRotation( Rotation idealRotation )
	{
		var player = Pawn as PlayerBase;

		//
		// Our ideal player model rotation is the way we're facing
		//
		var allowYawDiff = player?.ActiveChild == null ? 90 : 50;

		float turnSpeed = 0.01f;
		//if ( HasTag( "ducked" ) ) turnSpeed = 0.1f;

		//
		// If we're moving, rotate to our ideal rotation
		//
		Rotation = Rotation.Slerp( Rotation, idealRotation, WishVelocity.Length * Time.Delta * turnSpeed );

		//
		// Clamp the foot rotation to within 120 degrees of the ideal rotation
		//
		Rotation = Rotation.Clamp( idealRotation, allowYawDiff, out var change );

		//
		// If we did restrict, and are standing still, add a foot shuffle
		//
		if ( change > 1 && WishVelocity.Length <= 1 ) TimeSinceFootShuffle = 0;
	}

	void DoWalk()
	{
		// Move Speed
		{
			var dir = Velocity;
			var forward = Rotation.Forward.Dot( dir );
			var sideward = Rotation.Right.Dot( dir );

			var angle = MathF.Atan2( sideward, forward ).RadianToDegree().NormalizeDegrees();

			//SetAnimParameter( "move_direction", angle );
			//SetAnimParameter( "move_speed", Velocity.Length );
			//SetAnimParameter( "move_groundspeed", Velocity.WithZ( 0 ).Length );
			SetAnimParameter( "move_y", sideward );
			SetAnimParameter( "move_x", forward );
			//SetAnimParameter( "move_z", Velocity.z );
		}
	}

	public override void OnEvent( string name )
	{
		// DebugOverlay.Text( Pos + Vector3.Up * 100, name, 5.0f );

		base.OnEvent( name );
	}
}
