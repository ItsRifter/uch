using Sandbox;
public class UCHCamera : CameraMode
{
	Vector3 lastPos;

	public override void Activated()
	{
		var pawn = Local.Pawn;
		if ( pawn == null ) return;

		Position = pawn.EyePosition;
		Rotation = pawn.EyeRotation;

		lastPos = Position;
	}

	public override void Update()
	{
		var pawn = Local.Pawn;
		if ( pawn == null ) return;

		var eyePos = pawn.EyePosition;
		if ( eyePos.Distance( lastPos ) < 300 )
		{
			Position = Vector3.Lerp( eyePos.WithZ( lastPos.z ), eyePos, 20.0f * Time.Delta );
		}
		else
		{
			Position = eyePos;
		}

		Rotation = pawn.EyeRotation;

		Viewer = pawn;
		lastPos = Position;
	}
}
