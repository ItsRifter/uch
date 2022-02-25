using Sandbox.UI;

public partial class Hud : Sandbox.HudEntity<RootPanel>
{
	public Hud()
	{
		if ( IsClient )
		{
			RootPanel.SetTemplate( "/minimalhud.html" );

			RootPanel.AddChild<ChatBox>();
			RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();
		}
	}
}

