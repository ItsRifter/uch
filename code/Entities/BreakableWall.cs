using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sandbox;

[Library( "uch_breakable", Description = "Acts the same as a func_breakable" )]
[Hammer.Model]
[Hammer.SupportsSolid]
[Hammer.RenderFields]
partial class BreakableWall : AnimEntity
{
	[Property( "Health until break" )] 
	public float HealthUntilBreak { get; set; }

	[Property("Can Pigmasks destroy this")]
	public bool CanPigmasksDestroy { get; set; }

	[Property( "destroy_sound", Title = "Destruction Sound" ), FGDType( "sound" )]
	public string DestroyedSound { get; set; }

	protected Output OnBroken { get; set; }

	public override void Spawn()
	{
		base.Spawn();
		SetupPhysicsFromModel( PhysicsMotionType.Keyframed );
	}

	public override void TakeDamage( DamageInfo info )
	{
		if ( info.Attacker is PlayerBase player )
		{
			if ( player.CurrentTeam == PlayerBase.TeamEnum.Pigmask && !CanPigmasksDestroy )
				return;
		}

		HealthUntilBreak -= info.Damage;

		if ( HealthUntilBreak <= 0 )
		{
			Sound.FromWorld( DestroyedSound, Position);
			_ = OnBroken.Fire( this );
			OnKilled();
		}
	}
}
