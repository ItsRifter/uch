using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class Notify : Panel
{
	private Label pigRankLbl;
	private Label objectiveLbl;
	private Label endRoundLbl;

	private TimeSince startRoundTime;
	private TimeSince endRoundTime;
	private bool isNewRound;
	private bool isPostRound;

	public Notify()
	{
		StyleSheet.Load( "UI/Notify.scss" );

		pigRankLbl = Add.Label( "" );
		objectiveLbl = Add.Label( "", "objective" );
		endRoundLbl = Add.Label( "", "endgame" );
		isNewRound = true;
		isPostRound = false;
		startRoundTime = 0.0f;
		endRoundTime = 10f;
	}

	private void NotifyPlayers()
	{
		isNewRound = false;
		isPostRound = true;
		startRoundTime = 0;

		if (Local.Pawn is PlayerBase player)
		{
			if(player.CurrentTeam == PlayerBase.TeamEnum.Pigmask)
			{
				switch(player.CurrentPigRank)
				{
					case PlayerBase.PigRank.Ensign:
						pigRankLbl.SetText( "You are an Ensign" );
						break;

					case PlayerBase.PigRank.Captain:
						pigRankLbl.SetText( "You are a Captain" );
						break;

					case PlayerBase.PigRank.Major:
						pigRankLbl.SetText( "You are a Major" );
						break;

					case PlayerBase.PigRank.Colonel:
						pigRankLbl.SetText( "You are a Colonel" );
						break;
				}

				foreach ( var client in Client.All)
				{
					if( client.Pawn is PlayerBase chimera && chimera.CurrentTeam == PlayerBase.TeamEnum.Chimera)
						objectiveLbl.SetText( client.Name + " Is the Chimera, turn them off!" );
				}
			} else if (player.CurrentTeam == PlayerBase.TeamEnum.Chimera)
			{
				pigRankLbl.SetText( "" );
				objectiveLbl.SetText("You are the Chimera, eat all the pigmasks!" );
			}
		}
	}
	private void NotifyPlayersPostRound()
	{
		endRoundTime = 0f;

		isNewRound = true;
		isPostRound = false;

		var curPlayer = Local.Pawn as PlayerBase;

		if ( curPlayer == null )
			return;

		bool chimeraAlive = true;
		bool roundDraw = false;

		foreach ( var client in Client.All )
		{
			if(client.Pawn is PlayerBase player)
			{
				if ( !player.DidDisableChimera && player.CurrentTeam == PlayerBase.TeamEnum.Pigmask )
				{
					roundDraw = true;
				}

				if ( player.DidDisableChimera )
					chimeraAlive = false;
			}
		}

		if ( chimeraAlive && !roundDraw )
		{
			endRoundLbl.SetText( "The Chimera has devoured the pigmasks!" );
		} else if ( !chimeraAlive && !roundDraw )
		{
			endRoundLbl.SetText( "The pigmasks has conquered the Chimera!" );
		} else if ( roundDraw )
		{
			endRoundLbl.SetText( "Its a draw, nobody wins!" );
		}
	}

	public override void Tick()
	{
		base.Tick();

		if ( Game.Current.CurrentRoundStatus == Game.RoundEnum.Active && isNewRound )
		{
			NotifyPlayers();
			endRoundLbl.SetText( "" );
		}
		else if ( Game.Current.CurrentRoundStatus == Game.RoundEnum.Post && isPostRound )
		{
			NotifyPlayersPostRound();
			pigRankLbl.SetText( "" );
			objectiveLbl.SetText("");
		}

		SetClass( "active", startRoundTime < 4.0f || endRoundTime < 4.0f );
		SetClass( "show", startRoundTime < 6.0f || endRoundTime < 6.0f );
	}
}
