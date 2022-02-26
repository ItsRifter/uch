using Sandbox;
public class UCHThirdPersonCamera : CameraMode
{
	[ConVar.Replicated]
	public static bool thirdperson_collision { get; set; } = true;

	public override void Update()
	{
		var pawn = Local.Pawn as AnimEntity;
		var client = Local.Client;

		if ( pawn == null )
			return;

		Position = pawn.Position;
		Vector3 targetPos;

		var center = pawn.Position + Vector3.Up * 64;
		
		Position = center;
		Rotation = Rotation.FromAxis( Vector3.Up, 4 ) * Input.Rotation;

		float distance = 130.0f * pawn.Scale;
		targetPos = Position + Input.Rotation.Right * ((pawn.CollisionBounds.Maxs.x + 15) * pawn.Scale);
		targetPos += Input.Rotation.Forward * -distance;
		
		if ( thirdperson_collision )
		{
			var tr = Trace.Ray( Position, targetPos )
				.Ignore( pawn )
				.Radius( 8 )
				.Run();

			Position = tr.EndPosition;
		}
		else
		{
			Position = targetPos;
		}

		FieldOfView = 70;

		Viewer = null;
	}

	public override void BuildInput( InputBuilder input )
	{
		base.BuildInput( input );
	}
}
