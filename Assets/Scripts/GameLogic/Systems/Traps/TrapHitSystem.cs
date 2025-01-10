using GameLogic.Components.Combat;
using GameLogic.Components.Common;
using GameLogic.Components.Traps;
using GameLogic.UnityComponents;
using Leopotam.Ecs;

namespace GameLogic.Systems.Traps
{
	sealed class TrapHitSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsWorld _world = null;
		private EcsFilter<TrapFlag, OnTriggerStayEvent> _hitFilter = null;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _hitFilter)
			{
				ref EcsEntity trap = ref _hitFilter.GetEntity (i);
				if (!trap.Has<Cooldown> ())
				{
					MonoEntity targetMonoEntity = _hitFilter.Get2 (i).Value.GetComponent<MonoEntity> ();
					if (targetMonoEntity != null && targetMonoEntity.Entity.Has<Health> ())
						_world.NewEntity ().Get<DamageEvent> () = new DamageEvent { Target = targetMonoEntity.Entity, Value = trap.Get<Damage> ().Value };
					trap.Get<Cooldown> () = new Cooldown { Value = trap.Get<CooldownCharacteristic> ().Value };
				}
				trap.Del<OnTriggerStayEvent> ();
			}
		}
	}
}