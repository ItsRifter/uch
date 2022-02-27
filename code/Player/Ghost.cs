using Sandbox;
using System;
using System.Linq;

partial class PlayerBase
{
	private Vector3 restorePos;

	public void SpawnAsGhost()
	{
		CurrentTeam = TeamEnum.Spectator;
		SetModel( "models/player/ghost/ghost.vmdl" );

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
			return;
		}

		if ( !restorePos.IsNaN )
			Position = restorePos;
		else
			Position = randomSpawnPoint.Position;
	}

	public void SpawnAsFancyGhost()
	{
		CurrentTeam = TeamEnum.Spectator;
		SetModel( "models/player/ghost/ghost_fancy.vmdl" );

		Controller = new GhostController();
		CameraMode = new UCHCamera();

		EnableAllCollisions = false;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		var spawnpoints = Entity.All.OfType<PigmaskSpawn>();
		var randomSpawnPoint = spawnpoints.OrderBy( x => Guid.NewGuid() ).FirstOrDefault();

		if ( !restorePos.IsNaN )
			Position = restorePos;
		else
			Position = randomSpawnPoint.Position;
	}

	public void SpawnAsGhostAtLocation(Vector3 location)
	{
		restorePos = location;

		SpawnAsGhost();
	}
}
