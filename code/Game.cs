
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;


public partial class Game : Sandbox.Game
{
	public static new Game Current => Sandbox.Game.Current as Game;

	private Sound currentSound;

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

		PlayMusicClient( To.Single( player ), "waiting" );

		//Rifter (Me :D) has joined
		if( client.PlayerId == 76561197972285500 )
			player.SpawnAsFancyGhost();
		
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
}
