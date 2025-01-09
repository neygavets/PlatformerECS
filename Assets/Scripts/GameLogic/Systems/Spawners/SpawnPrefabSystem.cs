using GameLogic.UnityComponents;
using Leopotam.Ecs;

namespace Spawners {
	public class SpawnPrefabSystem : IEcsPreInitSystem, IEcsRunSystem {
		// auto-injected fields.
		private EcsWorld world;
		private SceneData sceneData;
		private EcsFilter<SpawnPrefab> spawnFilter = null;
		private PrefabFactory factory;

		public void PreInit () {
			factory = sceneData.factory;
			factory.Init (world);
		}

		public void Run () {
			foreach (int index in spawnFilter) {
				ref EcsEntity spawnEntity = ref spawnFilter.GetEntity (index);
				SpawnPrefab spawnPrefabData = spawnEntity.Get<SpawnPrefab> ();
				factory.Spawn (spawnEntity, spawnPrefabData);
				spawnEntity.Del<SpawnPrefab> ();
			}
		}
	}
}