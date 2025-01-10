using Leopotam.Ecs;

namespace GameLogic.Components.Combat
{
	struct DamageEvent
	{
		public int Value;
		public EcsEntity Target;
	}
}