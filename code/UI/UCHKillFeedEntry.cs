using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
public partial class UCHKillFeedEntry : Panel
{
	public Label Left { get; internal set; }
	public Label Right { get; internal set; }
	public Image Method { get; internal set; }

	public RealTimeSince TimeSinceBorn = 0;

	public UCHKillFeedEntry()
	{
		StyleSheet.Load( "UI/UCHKillFeedEntry.scss" );

		Left = Add.Label( "", "left" );
		Method = Add.Image( "", "method" );
		Right = Add.Label( "", "right" );
	}

	public override void Tick()
	{
		base.Tick();

		if ( TimeSinceBorn > 6 )
		{
			Delete();
		}
	}

}
