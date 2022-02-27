using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class Statuses : Panel
{
	public Panel StaminaBar;


	public Statuses()
	{
		StyleSheet.Load( "UI/Statuses.scss" );

		StaminaBar = Add.Panel( "ensign" );
		StaminaBar.SetClass( "ensign", true );
	}

	public override void Tick()
	{
		base.Tick();

		Style.Dirty();
		if (Local.Pawn != null && Local.Pawn is PlayerBase player)
		{
			if ( player.CurrentTeam == PlayerBase.TeamEnum.Spectator || player.CurrentTeam == PlayerBase.TeamEnum.Chimera )
			{
				Style.Width = 0;
				return;
			}
			if ( player.CurrentTeam == PlayerBase.TeamEnum.Pigmask )
			{
				Style.Width = Length.Percent(player.StaminaAmount / 10);
			}
		}	
	}
}
