using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class UCHKillFeed : Panel
{
	public static UCHKillFeed Current;

	public UCHKillFeed()
	{
		Current = this;

		StyleSheet.Load( "UI/UCHKillFeed.scss" );
	}

	public virtual Panel AddEntry( long lsteamid, string left, long rsteamid, string right, string method )
	{
		var e = Current.AddChild<UCHKillFeedEntry>();

		e.Left.Text = left;
		e.Left.SetClass( "me", lsteamid == (Local.Client?.PlayerId) );

		if ( method == "chimera" )
			e.Method.SetTexture("ui/killedby_chimera.png");
		else if (method == "pigmask" )
			e.Method.SetTexture( "ui/killedby_pigmask.png" );
		else if (method == "suicide")
			e.Method.SetTexture( "ui/killedby_self.png" );


		e.Right.Text = right;
		e.Right.SetClass( "me", rsteamid == (Local.Client?.PlayerId) );

		return e;
	}
}
