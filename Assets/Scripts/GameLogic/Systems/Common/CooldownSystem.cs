using Leopotam.Ecs;
using UnityEngine;

namespace Common {
	sealed class CooldownSystem : IEcsRunSystem {
		// auto-injected fields.
		private EcsFilter<Cooldown> cooldownFilter = null;

		void IEcsRunSystem.Run () {
			foreach (int index in cooldownFilter) {
				float cooldownTime = cooldownFilter.Get1 (index).Value;
				cooldownTime -= Time.deltaTime;
				if (cooldownTime <= 0)
					cooldownFilter.GetEntity (index).Del<Cooldown> ();
				else
					cooldownFilter.Get1 (index).Value = cooldownTime;
			}
		}
	}
}