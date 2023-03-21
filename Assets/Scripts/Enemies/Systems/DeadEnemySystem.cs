using Combat;
using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Enemies {
	sealed class DeadEnemySystem : IEcsRunSystem {
		// auto-injected fields.
		private EcsFilter<DeadFlag, EnemyFlag> deadFilter = null;
		private SceneData sceneData;

		void IEcsRunSystem.Run () {
			foreach (int i in deadFilter) {
				ref EcsEntity entity = ref deadFilter.GetEntity (i);
				entity.Del<DeadFlag> ();			

				//TODO: Обработка смерти врага
				Debug.Log ("Враг повержен: " + entity.Get<GameObjectLink> ().Value.name);

				GameObject.Destroy (entity.Get<GameObjectLink> ().Value);
				entity.Destroy ();
			}
		}
	}
}