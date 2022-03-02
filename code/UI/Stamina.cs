using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class Stamina : Panel
{
	public Panel StaminaBar;
	private float rankMultiply;

	public Stamina()
	{
		StyleSheet.Load( "UI/Stamina.scss" );

		StaminaBar = Add.Panel( "stamina" );
	}

	public override void Tick()
	{
		base.Tick();

		if (Local.Pawn != null && Local.Pawn is PlayerBase player)
		{
			StaminaBar.Style.Dirty();
			if ( player.CurrentTeam == PlayerBase.TeamEnum.Spectator || player.CurrentTeam == PlayerBase.TeamEnum.Chimera )
				StaminaBar.Style.Width = 0;

			if ( player.CurrentTeam == PlayerBase.TeamEnum.Pigmask )
			{
				switch ( player.CurrentPigRank )
				{
					case PlayerBase.PigRank.Ensign:
						rankMultiply = 4.5f;
						break;
					case PlayerBase.PigRank.Captain:
						rankMultiply = 3.65f;
						break;
					case PlayerBase.PigRank.Major:
						rankMultiply = 2.95f;
						break;
					case PlayerBase.PigRank.Colonel:
						rankMultiply = 2.25f;
						break;
				}

				StaminaBar.Style.Width = player.StaminaAmount * rankMultiply;
			}
		}	
	}
}
