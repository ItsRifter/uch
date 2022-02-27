using Sandbox;
using System;
using System.Linq;
partial class PlayerBase
{
	private TimeSince timeSinceTaunt;

	public enum PigRank
	{
		Ensign,
		Captain,
		Major,
		Colonel
	}

	public PigRank CurrentPigRank = PigRank.Ensign;

	public void SpawnAsPigmask()
	{
		CurrentTeam = TeamEnum.Pigmask;

		Controller = new PigmaskController();
		CameraMode = new UCHCamera();

		EnableAllCollisions = true;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		string spawnSound = "ensign_spawn";

		if ( CurrentPigRank == PigRank.Ensign )
		{
			SetModel( "models/player/pigmask/pigmask.vmdl" );
			spawnSound = "ensign_spawn";
			StaminaAmount = 100.0f;
		}
		else if ( CurrentPigRank == PigRank.Captain )
		{
			SetModel( "models/player/pigmask/pigmask_captain.vmdl" );
			spawnSound = "captain_spawn";
			StaminaAmount = 125.0f;
		}
		else if ( CurrentPigRank == PigRank.Major )
		{
			SetModel( "models/player/pigmask/pigmask_major.vmdl" );
			spawnSound = "major_spawn";
			StaminaAmount = 150.0f;
		}
		else if ( CurrentPigRank == PigRank.Colonel )
		{
			SetModel( "models/player/pigmask/pigmask_colonel.vmdl" );
			spawnSound = "colonel_spawn";
			StaminaAmount = 200.0f;
		}

		using ( Prediction.Off() )
			Game.Current.PlaySoundToClient( To.Single( this ), spawnSound );

		var spawnpoints = Entity.All.OfType<PigmaskSpawn>();
		var randomSpawnPoint = spawnpoints.OrderBy( x => Guid.NewGuid() ).FirstOrDefault();

		if ( randomSpawnPoint == null )
		{
			Log.Error( "THIS MAP ISN'T SUPPORTED FOR ULTIMATE CHIMERA HUNT" );
			base.Respawn();
			return;
		}

		Position = randomSpawnPoint.Position;

	}
	public void Taunt()
	{
		Log.Info( "Taunting" );

		CameraMode = new UCHTauntCamera();

		timeSinceTaunt = 0;
		IsTaunting = true;
		CanMove = false;

		SetAnimParameter( "taunt", true );
	}

	public void ResetRank()
	{
		CurrentPigRank = PigRank.Ensign;
	}

	[Event("evnt_rankup")]
	public void Rankup()
	{
		if ( CurrentPigRank == PigRank.Ensign )
		{
			CurrentPigRank = PigRank.Captain;
			return;
		}

		else if ( CurrentPigRank == PigRank.Captain )
		{ 
			CurrentPigRank = PigRank.Major;
			return;
		}
		else if ( CurrentPigRank == PigRank.Major )
		{ 
			CurrentPigRank = PigRank.Colonel;
			return;
		}
	}
}
