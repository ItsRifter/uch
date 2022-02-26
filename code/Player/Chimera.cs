using Sandbox;
using System.Linq;

partial class PlayerBase
{
	public bool ActiveChimera;
	private TimeSince timeLastBite;

	public void SpawnAsChimera()
	{
		CurrentTeam = TeamEnum.Chimera;

		SetModel( "models/player/chimera/chimera.vmdl" );

		CameraMode = new ChimeraCamera();

		timeLastBite = 0;

		ActiveChimera = true;
		EnableHitboxes = true;

		EnableAllCollisions = true;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		Position = All.OfType<ChimeraSpawn>().FirstOrDefault().Position;
	}

	//When the button on the chimera's back is pressed, turn off the chimera
	public void BackButtonPressed()
	{
		Sound.FromEntity( "button_press", this);
		ActiveChimera = false;
		EnableAllCollisions = false;
		OnKilled();
	}

	public bool CanBite()
	{
		if ( timeLastBite >= 1.25f && GroundEntity != null)
			return true;

		return false;
	}

	public void Bite()
	{
		var tr = Trace.Box( new Vector3(25, 25, 25), EyePosition, EyePosition + EyeRotation.Forward * 95 )
			.Size( 10 )
			.Ignore( this )
			.Run();

		using ( Prediction.Off() )
			Sound.FromEntity( "bite", this );
		
		Sound.FromEntity( "bite", this);

		SetAnimParameter( "bite", true );

		timeLastBite = 0;
		CanMove = false;

		if (tr.Entity is PlayerBase player)
		{
			if ( player.CurrentTeam == TeamEnum.Pigmask )
			{
				Game.roundTimer -= 30.0f;
				if ( Game.roundTimer <= 0.0f )
					Game.roundTimer = 0.0f;
				player.OnKilled();
			}
		}
	}
}
