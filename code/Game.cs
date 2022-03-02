
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

public partial class Game : Sandbox.Game
{
	public static new Game Current => Sandbox.Game.Current as Game;

	private List<string> maps;

	private Sound currentSound;

	private Hud oldHud;
	public Game()
	{
		if ( IsServer )
		{ 
			GrabSupportedMaps();
			CurrentRoundStatus = RoundEnum.Idle;
		}

		if ( IsClient )
		{
			oldHud = new Hud();
		}
	}

	[Event.Hotload]
	public void UpdateHUD()
	{
		oldHud?.Delete();

		if(IsClient)	
			oldHud = new Hud();
	}

	public override void DoPlayerSuicide( Client cl )
	{
	}

	public override void ClientJoined( Client client )
	{
		base.ClientJoined( client );

		var player = new PlayerBase();
		client.Pawn = player;

		player.InitialSpawn();

		CheckRoundStatus();

		PlayMusicClient( To.Single( player ), "waiting" );

		if (Client.All.Count >= 2)
			StartGame();
	}

	[ClientRpc]
	private void PlaySoundToClient( string soundPath )
	{
		Sound.FromScreen( soundPath );
	}

	[ClientRpc]
	private void PlayMusicClient( string soundPath )
	{
		currentSound = Sound.FromScreen( soundPath );
	}

	[ClientRpc]
	private void StopMusicClient()
	{
		currentSound.Stop();
	}

	private void PlayMusic()
	{
		using(Prediction.Off())
			PlayMusicClient( To.Everyone, "music" );
	}

	public override void ClientDisconnect( Client cl, NetworkDisconnectionReason reason )
	{
		base.ClientDisconnect( cl, reason );

		CheckRoundStatus();
	}

	public void GrabSupportedMaps()
	{
		maps = new List<string>();

		maps.Add( "rifter.club_titiboo" );
		maps.Add( "rifter.tazmily_village" );
	}

	public void CloseLobby()
	{
		string changeMap = "";
		changeMap = maps[Rand.Int( 0, maps.Count - 1 )];
		
		if( changeMap == Global.MapName )
		{
			while ( changeMap == Global.MapName )
				changeMap = maps[Rand.Int( 0, maps.Count - 1 )];
		}

		Global.ChangeLevel( changeMap );
	}
}
