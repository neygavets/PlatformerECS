using Leopotam.Ecs;

namespace Spawners {
	public class SpawnSystem : IEcsPreInitSystem, IEcsRunSystem {
		// auto-injected fields.
		private EcsWorld world;
		private SceneData sceneData;
		private EcsFilter<SpawnPrefab> spawnFilter = null;
		private PrefabFactory factory;

		public void PreInit () {
			factory = sceneData.Factory;
			factory.Init (world);
		}

		public void Run () {
			foreach (int index in spawnFilter) {
				ref EcsEntity spawnEntity = ref spawnFilter.GetEntity (index);
				var spawnPrefabData = spawnEntity.Get<SpawnPrefab> ();
				factory.Spawn (spawnEntity, spawnPrefabData);
				spawnEntity.Del<SpawnPrefab> ();
			}
		}
	}
}