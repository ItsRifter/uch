using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class Timer : Panel
{
	public string TimeLeft => $"{ Math.Max( 0, Game.Current.RoundTimer - Time.Now ).CeilToInt() }";

	public Label TimeLbl;
	public Panel timeHud;

	public Timer()
	{
		StyleSheet.Load( "UI/Timer.scss" );
		timeHud = Add.Panel("hud");
		TimeLbl = timeHud.Add.Label("Waiting for players", "text");
	}


	public override void Tick()
	{
		base.Tick();

		TimeSpan timeDuration = TimeSpan.FromSeconds( Game.Current.RoundTimer - Time.Now );

		TimeLbl.SetClass( "active", Game.Current.CurrentRoundStatus == Game.RoundEnum.Active );
		TimeLbl.SetClass( "post", Game.Current.CurrentRoundStatus == Game.RoundEnum.Post );

		if ( Game.Current.RoundTimer >= 0 && Game.Current.CurrentRoundStatus == Game.RoundEnum.Starting )
			TimeLbl.Text = "Starting in " + timeDuration.ToString( @"m\:ss" );
		else if ( Game.Current.CurrentRoundStatus == Game.RoundEnum.Active )
			TimeLbl.Text = "Time left: " + timeDuration.ToString( @"m\:ss" );
		else if ( Game.Current.CurrentRoundStatus == Game.RoundEnum.Post && Game.Current.RoundCount < Game.Current.MaxRounds )
			TimeLbl.Text = "Restarting in " + timeDuration.ToString( @"m\:ss" );
		else if ( Game.Current.CurrentRoundStatus == Game.RoundEnum.Post && Game.Current.RoundCount >= Game.Current.MaxRounds )
		{
			TimeLbl.SetClass( "gameover", true );
			TimeLbl.Text = "GAME OVER";
		}
		var player = Local.Pawn as PlayerBase;
		
		if ( player == null )
			return;

		timeHud.SetClass( "default", player.CurrentTeam == PlayerBase.TeamEnum.Spectator );

		if(player.CurrentTeam == PlayerBase.TeamEnum.Pigmask)
		{
			timeHud.SetClass( "chimera", false );
			timeHud.SetClass( "ensign", player.CurrentPigRank == PlayerBase.PigRank.Ensign );
			timeHud.SetClass( "captain", player.CurrentPigRank == PlayerBase.PigRank.Captain );
			timeHud.SetClass( "major", player.CurrentPigRank == PlayerBase.PigRank.Major );
			timeHud.SetClass( "colonel", player.CurrentPigRank == PlayerBase.PigRank.Colonel );

		} else if (player.CurrentTeam == PlayerBase.TeamEnum.Chimera)
			timeHud.SetClass( "chimera", player.CurrentTeam == PlayerBase.TeamEnum.Chimera );
	}
}
