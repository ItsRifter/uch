
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;


public partial class Game : Sandbox.Game
{
	private Hud oldHud;
	public Game()
	{
		if ( IsServer )
		{
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

		if(Client.All.Count >= 2)
			StartGame();
	}

	private void PlayMusic()
	{
		
		foreach ( var client in Client.All )
		{
			if ( client is PlayerBase player )
			{
				using ( Prediction.Off() )
					Sound.FromScreen("music");
			}
		}
		
	}

	public override void ClientDisconnect( Client cl, NetworkDisconnectionReason reason )
	{
		base.ClientDisconnect( cl, reason );

		if ( Client.All.Count < 2 )
			StopGame();

		CheckRoundStatus();
	}
}
