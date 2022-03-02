using Sandbox.UI;

public partial class Hud : Sandbox.HudEntity<RootPanel>
{
	public Hud()
	{
		//TEMPORARY
		RootPanel.AddChild<ChatBox>();
		RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();
		RootPanel.AddChild<KillFeed>();
		RootPanel.AddChild<NameTags>();

		RootPanel.AddChild<Stamina>();
		RootPanel.AddChild<Statuses>();
		RootPanel.AddChild<Timer>();
		RootPanel.AddChild<RoundCounter>();
		RootPanel.AddChild<Notify>();
	}
}

