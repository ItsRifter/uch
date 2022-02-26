using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class Statuses : Panel
{
	public Panel StaminaBarColour;


	public Statuses()
	{
		StyleSheet.Load( "UI/Statuses.scss" );

		StaminaBarColour = Add.Panel( "pigmask_ensign_stamina" );
	}

	public override void Tick()
	{
		base.Tick();

		if (Local.Pawn != null && Local.Pawn is PlayerBase player)
		{
			if ( player.CurrentTeam == PlayerBase.TeamEnum.Spectator ) return;

			if ( player.CurrentTeam == PlayerBase.TeamEnum.Pigmask )
			{
				Style.Dirty();
				Style.Width = Length.Percent( player.StaminaAmount / 10 );
			}

			
		}	
	}
}
