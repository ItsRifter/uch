
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
		if ( IsServer ) return;
		oldHud?.Delete();

		oldHud = new Hud();
	}

	public override void ClientJoined( Client client )
	{
		base.ClientJoined( client );

		var player = new PlayerBase();
		client.Pawn = player;

		player.InitialSpawn();

		if(Client.All.Count >= 2)
			StartGame();
		else if (Client.All.Count < 2)
			StopGame();
		
	}
}
