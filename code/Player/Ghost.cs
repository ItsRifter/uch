using Sandbox;
using System;
using System.Linq;

partial class PlayerBase
{
	public void SpawnAsGhost()
	{
		CurrentTeam = TeamEnum.Spectator;
		SetModel( "models/player/ghost/ghost.vmdl" );
		ResetRank();

		Controller = new GhostController();
		CameraMode = new UCHCamera();

		EnableAllCollisions = false;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		var spawnpoints = Entity.All.OfType<PigmaskSpawn>();
		var randomSpawnPoint = spawnpoints.OrderBy( x => Guid.NewGuid() ).FirstOrDefault();

		if ( randomSpawnPoint == null )
		{
			Log.Error( "THIS MAP ISN'T SUPPORTED FOR ULTIMATE CHIMERA HUNT" );
			base.Respawn();
			return;
		}

		Position = randomSpawnPoint.Position;
	}

	public void SpawnAsFancyGhost()
	{
		SetModel( "models/player/ghost/ghost_fancy.vmdl" );
		ResetRank();

		Controller = new GhostController();
		CameraMode = new UCHCamera();

		EnableAllCollisions = false;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		var spawnpoints = Entity.All.OfType<PigmaskSpawn>();
		var randomSpawnPoint = spawnpoints.OrderBy( x => Guid.NewGuid() ).FirstOrDefault();

		if ( randomSpawnPoint == null )
		{
			Log.Error( "THIS MAP ISN'T SUPPORTED FOR ULTIMATE CHIMERA HUNT" );
			base.Respawn();
			return;
		}
	}

	public void SpawnAsGhostAtLocation()
	{
		CurrentTeam = TeamEnum.Spectator;
		SetModel( "models/player/ghost/ghost.vmdl" );
		ResetRank();

		Controller = new GhostController();
		CameraMode = new UCHCamera();

		RenderColor = RenderColor.WithAlpha( 0.0f );

		EnableAllCollisions = false;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		Position = deathPosition;
	}

	public void SpawnAsFancyGhostAtLocation()
	{
		CurrentTeam = TeamEnum.Spectator;
		SetModel( "models/player/ghost/ghost_fancy.vmdl" );
		ResetRank();

		Controller = new GhostController();
		CameraMode = new UCHCamera();

		RenderColor = RenderColor.WithAlpha( 0.0f );

		EnableAllCollisions = false;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		Position = deathPosition;
	}
}
