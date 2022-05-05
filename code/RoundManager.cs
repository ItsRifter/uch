using Sandbox;
using System;
using System.Collections.Generic;

public partial class Game
{
	[Net] public float RoundTimer { get; set; }
	[Net] public int RoundCount { get; private set; } = 0;
	[Net] public int MaxRounds { get; private set; } = 15;
	[Net] public bool SaturnActive { get; private set; } = false;

	private TimeSince timeToShutdown;

	private PlayerBase lastChimera;
	public enum RoundEnum
	{
		Idle,
		Starting,
		Active,
		Post,
	}

	[Net, Change( nameof( OnStateChange ) )]
	public RoundEnum CurrentRoundStatus { get; private set; }

	public void OnStateChange( RoundEnum oldState, RoundEnum newState)
	{
	}

	[Event("startgame")]
	public void StartGame()
	{
		if ( CurrentRoundStatus != RoundEnum.Idle ) return;

		Log.Info( "Game is starting" );

		CurrentRoundStatus = RoundEnum.Starting;
		RoundTimer = 20.0f + Time.Now;
	}

	[AdminCmd( "uch_restartround" )]
	public static void RestartRoundCMD()
	{
		var caller = ConsoleSystem.Caller;

		if ( !caller.IsListenServerHost )
			return;

		Log.Info( "Round restarted by command" );
		Event.Run( "restartround", false, true );
	}

	[AdminCmd( "uch_forcestart")]
	public static void StartGameCMD()
	{
		var caller = ConsoleSystem.Caller;

		if ( !caller.IsListenServerHost )
			return;

		Event.Run( "startgame" );
	}

	public void SelectPlayerAsChimera()
	{
		List<PlayerBase> players = new List<PlayerBase>();

		foreach( var client in Client.All)
		{
			if ( client.Pawn is PlayerBase player )
				players.Add( player );
		}

		var selectedPlayer = players[Rand.Int( 0, players.Count - 1 )];

		if (lastChimera.IsValid())
		{
			while(lastChimera == selectedPlayer)
				selectedPlayer = players[Rand.Int( 0, players.Count - 1 )];
		}	

		selectedPlayer.SpawnAsChimera();
		lastChimera = selectedPlayer;

		Log.Info( selectedPlayer.Client.Name + " is the chimera" );
	}

	public void SpawnOthersAsPigmasks()
	{
		foreach ( var client in Client.All )
		{
			if ( client.Pawn is PlayerBase player && player.CurrentTeam != PlayerBase.TeamEnum.Chimera )
				player.SpawnAsPigmask();
			
		}
	}

	public void StopGame()
	{
		Log.Info( "Game stopped" );
		CurrentRoundStatus = RoundEnum.Idle;
	}

	public void BeginActiveRound()
	{
		if ( CurrentRoundStatus == RoundEnum.Active ) return;

		Map.Reset(DefaultCleanupFilter);

		SaturnActive = false;

		RoundCount++;

		using ( Prediction.Off() )
			StopMusicClient( To.Everyone );

		Log.Info( "Round active" );
		CurrentRoundStatus = RoundEnum.Active;

		foreach ( var client in Client.All)
		{
			if ( client.Pawn is PlayerBase player )
			{
				player.ResetPlayers();
				player.Respawn();
			}
		}

		SelectPlayerAsChimera();
		SpawnOthersAsPigmasks();

		PlayMusic();

		RoundTimer = 180.0f + Time.Now;
	}

	[AdminCmd( "uch_spawnsaturn" )]
	public static void SpawnSaturnCMD()
	{
		Event.Run( "spawnsaturn" );
	}

	[Event("spawnsaturn")]
	public void SpawnMrSaturn()
	{
		SaturnActive = true;

		Sound.FromScreen( "saturn_appear" );
		var saturn = new MrSaturn();
	}

	[Event.Tick.Server]
	public void UpdateTimer()
	{
		if ( CurrentRoundStatus == RoundEnum.Idle ) return;

		if ( (RoundTimer - Time.Now) <= 0 && CurrentRoundStatus == RoundEnum.Starting )
			BeginActiveRound();

		if((RoundTimer - Time.Now) <= 120.0f && !SaturnActive && CurrentRoundStatus == RoundEnum.Active)
		{
			SpawnMrSaturn();
		}

		if ( (RoundTimer - Time.Now) <= 0 && CurrentRoundStatus == RoundEnum.Post && RoundCount < MaxRounds )
		{
			if ( Client.All.Count < 2 )
				StopGame();
			else
				BeginActiveRound();
		}

		if( (RoundTimer - Time.Now) <= 0 && CurrentRoundStatus == RoundEnum.Active && RoundCount < MaxRounds )
		{
			EndRound(false, true);
		}

		if( RoundCount >= MaxRounds && timeToShutdown > 13.5f && CurrentRoundStatus == RoundEnum.Post)
		{
			if ( Host.IsServer )
				ChangeMap();
		}
	}

	public void CheckRoundStatus()
	{
		//Don't check status if the game is currently idle
		if ( CurrentRoundStatus == RoundEnum.Idle ) return;

		//If we're active, check the status of the round
		if ( CurrentRoundStatus == RoundEnum.Active )
		{
			List<PlayerBase> piggies = GetPiggies();
			
			if( piggies.Count <= 0 )
				EndRound( true, false );
			else if ( IsChimeraActive() == false)
				EndRound( false, false );
		}
	}

	[Event( "restartround" )]
	public void EndRound( bool chimeraWin, bool isDraw )
	{
		Log.Info( "Round has ended" );
		RoundTimer = 10 + Time.Now;

		CurrentRoundStatus = RoundEnum.Post;

		using ( Prediction.Off() )
			StopMusicClient( To.Everyone );

		if ( RoundCount >= MaxRounds )
		{
			using(Prediction.Off())
				PlaySoundToClient(To.Everyone, "gameover");

			timeToShutdown = 0;
			RoundTimer = 999;

			return;
		}

		if ( chimeraWin && !isDraw )
		{
			Log.Info( "Chimera Won" );
			foreach ( var client in Client.All )
			{
				if ( client.Pawn is PlayerBase player )
				{
					using ( Prediction.Off() )
					{
						if ( player.CurrentTeam == PlayerBase.TeamEnum.Pigmask || player.CurrentTeam == PlayerBase.TeamEnum.Spectator )
							PlaySoundToClient( To.Single( player ), "pigs_lose" );
						else if ( player.CurrentTeam == PlayerBase.TeamEnum.Chimera )
							PlaySoundToClient( To.Single( player ), "chimera_win" );
					}
				}
			}
		}
		else if ( !chimeraWin && !isDraw )
		{
			Log.Info( "Pigmasks Won" );
			foreach ( var client in Client.All )
			{
				if ( client.Pawn is PlayerBase player )
				{
					if ( player.CurrentTeam == PlayerBase.TeamEnum.Pigmask || player.CurrentTeam == PlayerBase.TeamEnum.Spectator )
						PlaySoundToClient( To.Single( player ), "pigs_win" );
					else if ( player.CurrentTeam == PlayerBase.TeamEnum.Chimera )
						PlaySoundToClient( To.Single( player ), "chimera_lose" );

				}
			}
		} else if ( isDraw )
		{
			Log.Info( "DRAW" );
			PlaySoundToClient( To.Everyone, "draw" );
		}
	}

	public bool IsChimeraActive()
	{
		foreach ( var client in Client.All )
		{
			if ( client.Pawn is PlayerBase player )
			{
				if ( player.CurrentTeam == PlayerBase.TeamEnum.Chimera )
				{
					return player.ActiveChimera;
				}
			}
		}

		return false;
	}

	public List<PlayerBase> GetPiggies()
	{
		List<PlayerBase> pigPlayers = new List<PlayerBase>();

		foreach(var client in Client.All )
		{
			if (client.Pawn is PlayerBase player)
			{
				if(player.CurrentTeam == PlayerBase.TeamEnum.Pigmask)
					pigPlayers.Add(player);
			}
		}

		return pigPlayers;
	}
}
