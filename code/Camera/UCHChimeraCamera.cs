using Sandbox;

public class UCHChimeraCamera : CameraMode
{
	[ConVar.Replicated]
	public static bool thirdperson_collision { get; set; } = true;

	private Angles rotAngle;

	public override void Update()
	{
		var pawn = Local.Pawn as AnimEntity;

		if ( pawn == null )
			return;

		Position = pawn.Position;
		Vector3 targetPos;

		var center = pawn.Position + Vector3.Up * 64;

		Position = center;
		Rotation = Input.Rotation;

		pawn.Rotation = Rotation.From( rotAngle );

		float distance = 130.0f * pawn.Scale;
		targetPos = Position;
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
		rotAngle.yaw = input.ViewAngles.yaw;

		base.BuildInput( input );
	}
}
