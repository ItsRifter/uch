using Sandbox;

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
		CameraMode = new FirstPersonCamera();


		EnableAllCollisions = true;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		string spawnSound = "ensign_spawn";

		if ( CurrentPigRank == PigRank.Ensign )
		{
			SetModel( "models/player/pigmask/pigmask.vmdl" );
			spawnSound = "ensign_spawn";
		}
		else if ( CurrentPigRank == PigRank.Captain )
		{
			SetModel( "models/player/pigmask/pigmask_captain.vmdl" );
			spawnSound = "captain_spawn";
		}
		else if ( CurrentPigRank == PigRank.Major )
		{
			SetModel( "models/player/pigmask/pigmask_major.vmdl" );
			spawnSound = "major_spawn";
		}
		else if ( CurrentPigRank == PigRank.Colonel )
		{
			SetModel( "models/player/pigmask/pigmask_colonel.vmdl" );
			spawnSound = "colonel_spawn";
		}
		using ( Prediction.Off() )
			PlaySoundToClient( To.Single( this ), spawnSound );
	}

	[ServerCmd("uch_rankup")]
	public static void RankUpCMD()
	{
		var player = ConsoleSystem.Caller.Pawn as PlayerBase;

		player.Rankup();
		player.SpawnAsPigmask();
	}

	public void Taunt()
	{
		Log.Info( "Taunting" );

		CameraMode = new ThirdPersonCamera();

		timeSinceTaunt = 0;
		IsTaunting = true;
		CanMove = false;

		Animator.SetAnimParameter( "taunt", true );
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
