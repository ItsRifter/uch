using Sandbox;
using System;
using System.Linq;

partial class PlayerBase
{
	public bool ActiveChimera;
	private TimeSince timeLastBite;

	public void SpawnAsChimera()
	{
		CurrentTeam = TeamEnum.Chimera;

		SetModel( "models/player/chimera/chimera.vmdl" );

		CameraMode = new UCHChimeraCamera();
		Controller = new ChimeraController();

		timeLastBite = 0;

		ActiveChimera = true;
		EnableHitboxes = true;

		EnableAllCollisions = true;
		EnableDrawing = true;
		EnableHideInFirstPerson = false;
		EnableShadowInFirstPerson = false;

		using ( Prediction.Off() )
			Game.Current.PlaySoundToClient( To.Single( this ), "chimera_spawn" );


		if ( All.OfType<ChimeraSpawn>().FirstOrDefault() == null )
		{
			Log.Error( "THIS MAP ISN'T SUPPORTED FOR ULTIMATE CHIMERA HUNT" );
			base.Respawn();
			return;
		}

		Position = All.OfType<ChimeraSpawn>().FirstOrDefault().Position;
	}

	//When the button on the chimera's back is pressed, turn off the chimera
	public void BackButtonPressed()
	{
		Sound.FromEntity( "button_press", this);
		ActiveChimera = false;
		EnableDrawing = false;
		EnableAllCollisions = false;
		OnKilled();
		BecomeChimeraRagdollClient( Velocity );
	}

	public bool CanBite()
	{
		if ( timeLastBite >= 1.25f && GroundEntity != null)
			return true;

		return false;
	}

	public void Bite()
	{
		if ( Game.Current.CurrentRoundStatus != Game.RoundEnum.Active ) return;

		var tr = Trace.Sphere(52, EyePosition, EyePosition + EyeRotation.Forward * 115 )
			.Size( 4 )
			.Ignore( this )
			.Run();

		using ( Prediction.Off() )
			Sound.FromEntity( "bite", this );

		SetAnimParameter( "bite", true );

		timeLastBite = 0;
		CanMove = false;

		if ( tr.Entity is not PlayerBase )
			return;

		var totalEnts = FindInSphere( tr.EndPosition + 12, 64 );

		foreach(var ent in totalEnts) 
		{
			if (ent is PlayerBase player)
				if ( player.CurrentTeam == TeamEnum.Pigmask )
				{
					Game.Current.RoundTimer += 30;

					player.BecomeRagdollOnClient( Velocity, EyePosition + Vector3.Up * 100 );

					player.OnKilled();
				}
		}
	}
}
