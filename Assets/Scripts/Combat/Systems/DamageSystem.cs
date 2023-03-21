using Common;
using Enemies;
using Leopotam.Ecs;
using UnityEngine;

namespace Combat {
	sealed class DamageSystem : IEcsRunSystem {
		// auto-injected fields.
		private EcsFilter<DamageEvent> damageFilter = null;
		private SceneData sceneData;

		void IEcsRunSystem.Run () {
			foreach (int i in damageFilter) {
				DamageEvent damageEvent = damageFilter.Get1 (i);
				ref EcsEntity targetEntity = ref damageEvent.Target;
				targetEntity.Get<Health> ().Current -= damageEvent.Value;
				if (targetEntity.Has<PlayerFlag> ())
					sceneData.playerInfo.UpdateHealth (targetEntity.Get<Health>());
				if (targetEntity.Has<EnemyBossFlag> ())
					sceneData.enemyInfo.UpdateHealth (targetEntity.Get<Health> ());
				if (targetEntity.Get<Health> ().Current <= 0)
					targetEntity.Get<DeadFlag> ();
				damageFilter.GetEntity (i).Destroy ();
			}
		}
	}
}