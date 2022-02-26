using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class Timer : Panel
{
	public TimeSince TimeUntilStart = 999;

	public Label TimeLbl;

	public Timer()
	{
		StyleSheet.Load( "UI/Timer.scss" );
		TimeLbl = Add.Label("Teach Rifter how to UI", "timer");
	}

	public override void Tick()
	{
		base.Tick();

		if ( TimeUntilStart < 20 )
			TimeLbl.Text = "Starting in " + MathF.Round(20 - TimeUntilStart).ToString();

	}
}
