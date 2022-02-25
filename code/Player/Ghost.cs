using Sandbox;

partial class PlayerBase
{
	public void SpawnAsGhost()
	{
		CurrentTeam = TeamEnum.Spectator;
		SetModel( "models/player/ghost/ghost.vmdl" );

		Controller = new GhostController();
	
		EnableAllCollisions = false;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = false;
	}

	public void SpawnAsGhostAtLocation(Vector3 location)
	{
		Position = location;

		SpawnAsGhost();
	}
}
