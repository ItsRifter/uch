using Sandbox;
using System;
using System.Collections.Generic;

public partial class Game
{
	private TimeSince timeTillUpdate;
	public static TimeSince roundTimer;
	private PlayerBase lastChimera;

	public enum RoundEnum
	{
		Idle,
		Starting,
		Active,
		Post,
	}

	public static RoundEnum CurrentRoundStatus = RoundEnum.Idle;

	[Event("startgame")]
	public void StartGame()
	{
		if ( CurrentRoundStatus != RoundEnum.Idle ) return;

		Log.Info( "Game is starting" );
		CurrentRoundStatus = RoundEnum.Starting;
		timeTillUpdate = 0;

		foreach ( var client in Client.All)
		{
			if ( client.Pawn is PlayerBase player )
				player.PlaySoundToClient( To.Single( player ), "waiting" );
		}
	}

	[ServerCmd("uch_forcestart")]
	public static void StartGameCMD()
	{
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

	public void ResetPlayers()
	{
		foreach ( var client in Client.All )
		{
			if ( client.Pawn is PlayerBase player )
			{
				player.SpawnAsGhost();
				player.Respawn();
			}
		}
	}

	public void StopGame()
	{
		CurrentRoundStatus = RoundEnum.Idle;
	}

	public void BeginActiveRound()
	{
		if ( CurrentRoundStatus == RoundEnum.Active ) return;

		Log.Info( "Round active" );
		CurrentRoundStatus = RoundEnum.Active;

		ResetPlayers();
		SelectPlayerAsChimera();
		SpawnOthersAsPigmasks();

		PlayMusic();

		roundTimer = 0;
	}

	[Event.Tick.Server]
	public void UpdateTimer()
	{
		if ( CurrentRoundStatus == RoundEnum.Idle ) return;

		if ( timeTillUpdate >= 20 && CurrentRoundStatus == RoundEnum.Starting )
			BeginActiveRound();

		if ( timeTillUpdate >= 10 && CurrentRoundStatus == RoundEnum.Post )
			BeginActiveRound();

		if( roundTimer >= 180 && CurrentRoundStatus == RoundEnum.Active)
		{
			EndRound(false, true);
		}
	}

	[Event( "evnt_roundstatus" )]
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

	public void EndRound(bool chimeraWin, bool isDraw)
	{
		Log.Info( "Round has ended" );
		timeTillUpdate = 0;
		CurrentRoundStatus = RoundEnum.Post;

		if (chimeraWin && !isDraw)
		{
			Log.Info( "Chimera Won" );
			foreach(var client in Client.All)
			{
				if(client.Pawn is PlayerBase player)
				{
					using(Prediction.Off())
					{
						if ( player.CurrentTeam == PlayerBase.TeamEnum.Pigmask || player.CurrentTeam == PlayerBase.TeamEnum.Spectator )
							player.PlaySoundToClient( To.Single( player ), "pig_lose" );
						else if ( player.CurrentTeam == PlayerBase.TeamEnum.Chimera )
							player.PlaySoundToClient( To.Single( player ), "chimera_win" );
					}
				}
			}	
		}
		else if (!chimeraWin && !isDraw)
		{
			Log.Info( "Pigmasks Won" );
			foreach ( var client in Client.All )
			{
				if ( client.Pawn is PlayerBase player )
				{

					if ( player.CurrentTeam == PlayerBase.TeamEnum.Pigmask || player.CurrentTeam == PlayerBase.TeamEnum.Spectator )
					{
						using ( Prediction.Off() )
							player.PlaySoundToClient( To.Single( player ), "pig_win" );
					}
					else if ( player.CurrentTeam == PlayerBase.TeamEnum.Chimera )
						using ( Prediction.Off() )
							player.PlaySoundToClient( To.Single( player ), "chimera_lose" );

				}
			}
		} else if ( isDraw )
		{
			Log.Info( "DRAW" );
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
