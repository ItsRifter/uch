using Sandbox.UI;

public partial class Hud : Sandbox.HudEntity<RootPanel>
{
	public Hud()
	{
		if ( IsClient )
		{
			//TEMPORARY
			RootPanel.AddChild<ChatBox>();
			RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();
			RootPanel.AddChild<KillFeed>();
			RootPanel.AddChild<NameTags>();

			RootPanel.AddChild<Timer>();
			RootPanel.AddChild<Statuses>();
		}
	}
}

