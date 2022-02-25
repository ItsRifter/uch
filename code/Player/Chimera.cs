﻿using Sandbox;

partial class PlayerBase
{
	public bool ActiveChimera;
	private TimeSince timeLastBite;

	public void SpawnAsChimera()
	{
		CurrentTeam = TeamEnum.Chimera;
		SetModel( "models/player/chimera/chimera.vmdl" );

		timeLastBite = 0;

		ActiveChimera = true;

		EnableAllCollisions = true;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = false;
	}

	//When the button on the chimera's back is pressed, turn off the chimera
	public void BackButtonPressed()
	{
		ActiveChimera = false;
		base.OnKilled();
	}

	public bool CanBite()
	{
		if ( timeLastBite >= 1.25f )
			return true;

		return false;
	}

	public void Bite()
	{
		var tr = Trace.Ray( EyePosition, EyePosition + EyeRotation.Forward * 50 )
			.Size( 10 )
			.Ignore( this )
			.Run();

		PlaySound( "bite" );

		timeLastBite = 0;

		if (tr.Entity is PlayerBase player)
		{
			if ( player.CurrentTeam == TeamEnum.Pigmask )
				player.OnKilled();
		}
	}
}
