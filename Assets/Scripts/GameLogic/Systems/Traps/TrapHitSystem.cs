using Combat;
using Common;
using GameLogic.UnityComponents;
using Leopotam.Ecs;

namespace Traps {
	sealed class TrapHitSystem : IEcsRunSystem {
		// auto-injected fields.
		readonly EcsWorld world = null;
		private EcsFilter<TrapFlag, OnTriggerStayEvent> hitFilter = null;

		void IEcsRunSystem.Run () {
			foreach (int i in hitFilter) {
				ref EcsEntity trap = ref hitFilter.GetEntity (i);
				if (!trap.Has<Cooldown> ()) {
					MonoEntity targetMonoEntity = hitFilter.Get2 (i).Value.GetComponent<MonoEntity> ();
					if (targetMonoEntity != null && targetMonoEntity.Entity.Has<Health> ())
						world.NewEntity ().Get<DamageEvent> () = new DamageEvent { Target = targetMonoEntity.Entity, Value = trap.Get<Damage> ().Value };
					trap.Get<Cooldown> () = new Cooldown { Value = trap.Get<CooldownCharacteristic> ().Value };
				}			
				trap.Del<OnTriggerStayEvent> ();				
			}
		}
	}
}