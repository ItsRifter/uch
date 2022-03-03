using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class Stamina : Panel
{
	public Panel ChimeraRoarBar;
	public Panel ChimeraTailBar;
	public Panel StandardStamina;

	public Stamina()
	{
		StyleSheet.Load( "UI/Stamina.scss" );

		StandardStamina = Add.Panel();
		ChimeraRoarBar = Add.Panel( "chimeraRoarBar" );
		ChimeraTailBar = Add.Panel( "chimeraTailBar" );
	}

	public override void Tick()
	{
		base.Tick();

		if (Local.Pawn != null && Local.Pawn is PlayerBase player)
		{
			Style.Dirty();
			if ( player.CurrentTeam == PlayerBase.TeamEnum.Pigmask )
			{
				float rankMultiply = 0.0f;

				SetClass( "isChimera", false );

				ChimeraRoarBar.Style.Opacity = 0;
				ChimeraTailBar.Style.Opacity = 0;

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

				StandardStamina.Style.Width = player.StaminaAmount * rankMultiply;
			}
			else if ( player.CurrentTeam == PlayerBase.TeamEnum.Chimera )
			{
				//Weirdly setting values without these breaks the UI
				float staminaMultiply = 1.90f;
				float roarMultiply = 5.75f;
				float tailMultiply = 2.85f;
				
				SetClass( "isChimera", true );
				
				ChimeraRoarBar.Style.Opacity = 1;
				ChimeraTailBar.Style.Opacity = 1;

				StandardStamina.Style.Width = player.ChimeraStaminaAmount * staminaMultiply;
				ChimeraRoarBar.Style.Width = player.ChimeraRoarAmount * roarMultiply;
				ChimeraTailBar.Style.Width = player.ChimeraTailStaminaAmount * tailMultiply;

			}
			
		}	
	}
}
