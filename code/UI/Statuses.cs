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


		Statues = Add.Panel( "statuses" );
	}

	public override void Tick()
	{
		base.Tick();

		if (Local.Pawn != null && Local.Pawn is PlayerBase player)
		{

			Statues.SetClass( "default", player.CurrentTeam == PlayerBase.TeamEnum.Spectator );

			if ( player.CurrentTeam == PlayerBase.TeamEnum.Spectator || player.CurrentTeam == PlayerBase.TeamEnum.Chimera )
			{
				Statues.SetClass( "ensign", false );
				Statues.SetClass( "captain", false );
				Statues.SetClass( "major", false );
				Statues.SetClass( "colonel", false );
			}

			if ( player.CurrentTeam == PlayerBase.TeamEnum.Pigmask )
			{
				Statues.SetClass( "ensign", player.CurrentPigRank == PlayerBase.PigRank.Ensign );
				Statues.SetClass( "captain", player.CurrentPigRank == PlayerBase.PigRank.Captain );
				Statues.SetClass( "major", player.CurrentPigRank == PlayerBase.PigRank.Major );
				Statues.SetClass( "colonel", player.CurrentPigRank == PlayerBase.PigRank.Colonel );
			}
		}	
	}
}
