using GameLogic.UnityComponents;
using Leopotam.Ecs;
using GameLogic.Components.Spawners;
using GameLogic.Models;

namespace GameLogic.Systems.Spawners
{
	public class SpawnPrefabSystem : IEcsPreInitSystem, IEcsRunSystem
	{
		// auto-injected fields.
		private EcsWorld _world;
		private SceneData _sceneData;
		private EcsFilter<SpawnPrefab> _spawnFilter = null;
		private PrefabFactory _factory;

		public void PreInit ()
		{
			_factory = _sceneData.factory;
			_factory.Init (_world);
		}

		public void Run ()
		{
			foreach (int index in _spawnFilter)
			{
				ref EcsEntity spawnEntity = ref _spawnFilter.GetEntity (index);
				SpawnPrefab spawnPrefabData = spawnEntity.Get<SpawnPrefab> ();
				_factory.Spawn (spawnEntity, spawnPrefabData);
				spawnEntity.Del<SpawnPrefab> ();
			}
		}
	}
}