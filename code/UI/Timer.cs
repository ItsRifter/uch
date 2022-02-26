using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class Timer : Panel
{
	public string TimeLeft => $"{ Math.Max( 0, Game.Current.RoundTimer - Time.Now ).CeilToInt() }";

	public Label TimeLbl;

	public Timer()
	{
		StyleSheet.Load( "UI/Timer.scss" );
		TimeLbl = Add.Label("Waiting for players", "timer");
	}

	public override void Tick()
	{
		base.Tick();

		if ( Game.Current.RoundTimer >= 0 && Game.Current.CurrentRoundStatus == Game.RoundEnum.Starting )
			TimeLbl.Text = "Starting in " + TimeLeft;
		else if ( Game.Current.CurrentRoundStatus == Game.RoundEnum.Active )
			TimeLbl.Text = "Time left: " + TimeLeft;
		else if ( Game.Current.CurrentRoundStatus == Game.RoundEnum.Post )
			TimeLbl.Text = "Restarting in " + TimeLeft;
	}
}
