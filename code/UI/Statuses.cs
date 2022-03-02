using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class Statuses : Panel
{
	public Panel Statues;

	public Statuses()
	{
		StyleSheet.Load( "UI/Statuses.scss" );

	}

	public override void Tick()
	{
		base.Tick();

		if (Local.Pawn != null && Local.Pawn is PlayerBase player)
		{

			SetClass( "default", player.CurrentTeam == PlayerBase.TeamEnum.Spectator );

			if ( player.CurrentTeam == PlayerBase.TeamEnum.Spectator || player.CurrentTeam == PlayerBase.TeamEnum.Chimera )
			{
				SetClass( "ensign", false );
				SetClass( "captain", false );
				SetClass( "major", false );
				SetClass( "colonel", false );
			}

			if ( player.CurrentTeam == PlayerBase.TeamEnum.Pigmask )
			{
				SetClass( "ensign", player.CurrentPigRank == PlayerBase.PigRank.Ensign );
				SetClass( "captain", player.CurrentPigRank == PlayerBase.PigRank.Captain );
				SetClass( "major", player.CurrentPigRank == PlayerBase.PigRank.Major );
				SetClass( "colonel", player.CurrentPigRank == PlayerBase.PigRank.Colonel );
			}
		}	
	}
}
