using Sandbox;
using System;
using System.Linq;
partial class PlayerBase
{
	private TimeSince timeSinceTaunt;
	private TimeSince timeLastScared;
	private TimeSince timeLastWhipped;

	private float StaminaMaxAmount;
	private float timeRandomSnort = 0.0f;

	public bool staminaExhausted = false;
	public bool IsScared = false;
	private bool isWhipped = false;

	public enum PigRank
	{
		Ensign,
		Captain,
		Major,
		Colonel
	}


	[Net, Change( nameof( OnRankChange ) )]
	public PigRank CurrentPigRank { get; private set; } = PigRank.Ensign;

	public void OnRankChange( PigRank oldRank, PigRank newRank )
	{
	}

	public void SpawnAsPigmask()
	{
		CurrentTeam = TeamEnum.Pigmask;

		timeRandomSnort = Rand.Float(5.0f, 12.0f) + Time.Now;

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
			StaminaMaxAmount = 100.0f;
		}
		else if ( CurrentPigRank == PigRank.Captain )
		{
			SetModel( "models/player/pigmask/pigmask_captain.vmdl" );
			spawnSound = "captain_spawn";
			StaminaMaxAmount = 125.0f;
		}
		else if ( CurrentPigRank == PigRank.Major )
		{
			SetModel( "models/player/pigmask/pigmask_major.vmdl" );
			spawnSound = "major_spawn";
			StaminaMaxAmount = 150.0f;
		}
		else if ( CurrentPigRank == PigRank.Colonel )
		{
			SetModel( "models/player/pigmask/pigmask_colonel.vmdl" );
			spawnSound = "colonel_spawn";
			StaminaMaxAmount = 200.0f;
		}

		StaminaAmount = StaminaMaxAmount;

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
		CameraMode = new UCHTauntCamera();

		
		isTaunting = true;
		CanMove = false;

		if ( CurrentPigRank == PigRank.Colonel )
		{
			SetAnimParameter( "b_taunt2", true );
			timeSinceTaunt = -1.0f;
		}
		else
		{
			SetAnimParameter( "b_taunt", true );
			timeSinceTaunt = 0;
		}
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
