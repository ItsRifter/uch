using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class RoundCounter : Panel
{
	public Label RoundLbl;
	public Panel RoundHud;

	public RoundCounter()
	{
		StyleSheet.Load( "UI/RoundCounter.scss" );
		RoundHud = Add.Panel("hud");
		RoundLbl = RoundHud.Add.Label( "", "text" );

		RoundHud.SetClass( "default", true );
	}

	public override void Tick()
	{
		base.Tick();

		RoundLbl.SetText("Round: " + Game.Current.RoundCount + "/" + Game.Current.MaxRounds);

		var player = Local.Pawn as PlayerBase;

		if ( player == null )
			return;

		RoundHud.SetClass( "default", player.CurrentTeam == PlayerBase.TeamEnum.Spectator );

		if ( player.CurrentTeam == PlayerBase.TeamEnum.Pigmask )
		{
			RoundHud.SetClass( "chimera", false );
			RoundHud.SetClass( "ensign", player.CurrentPigRank == PlayerBase.PigRank.Ensign );
			RoundHud.SetClass( "captain", player.CurrentPigRank == PlayerBase.PigRank.Captain );
			RoundHud.SetClass( "major", player.CurrentPigRank == PlayerBase.PigRank.Major );
			RoundHud.SetClass( "colonel", player.CurrentPigRank == PlayerBase.PigRank.Colonel );

		}
		else if ( player.CurrentTeam == PlayerBase.TeamEnum.Chimera )
			RoundHud.SetClass( "chimera", player.CurrentTeam == PlayerBase.TeamEnum.Chimera );
	}
}
