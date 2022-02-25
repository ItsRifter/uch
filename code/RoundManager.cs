using Sandbox;
using System;
using System.Collections.Generic;

public partial class Game
{
	private TimeSince timeTillUpdate;
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
				player.PlaySoundToClient( To.Single( this ), "waiting" );
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
	}

	[Event.Tick.Server]
	public void UpdateTimer()
	{
		if ( CurrentRoundStatus == RoundEnum.Idle ) return;

		if ( timeTillUpdate >= 20 && CurrentRoundStatus == RoundEnum.Starting )
			BeginActiveRound();

		if ( timeTillUpdate >= 10 && CurrentRoundStatus == RoundEnum.Post )
			BeginActiveRound();
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
				EndRound( true );
			else if ( IsChimeraActive() == false)
				EndRound( false );
		}
	}

	public void EndRound(bool chimeraWin)
	{
		Log.Info( "Round has ended" );
		timeTillUpdate = 0;
		CurrentRoundStatus = RoundEnum.Post;
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
