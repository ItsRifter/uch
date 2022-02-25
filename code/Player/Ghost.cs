using Sandbox;

partial class PlayerBase
{
	public void SpawnAsGhost()
	{
		CurrentTeam = TeamEnum.Spectator;
		SetModel( "models/player/ghost/ghost.vmdl" );

		Controller = new GhostController();
		CameraMode = new FirstPersonCamera();

		EnableAllCollisions = false;
		EnableDrawing = false;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;
	}

	public void SpawnAsGhostAtLocation(Vector3 location)
	{
		Position = location;

		SpawnAsGhost();
	}
}
