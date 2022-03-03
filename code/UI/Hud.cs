using Sandbox;
using Sandbox.UI;

public partial class Hud : Sandbox.HudEntity<RootPanel>
{
	public Hud()
	{
		RootPanel.AddChild<ChatBox>();
		RootPanel.AddChild<NameTags>();
		RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();

		RootPanel.AddChild<UCHKillFeed>();
		RootPanel.AddChild<Stamina>();
		RootPanel.AddChild<Statuses>();
		RootPanel.AddChild<Timer>();
		RootPanel.AddChild<RoundCounter>();
		RootPanel.AddChild<Notify>();
	}
}

