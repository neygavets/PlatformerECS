using Leopotam.Ecs;
using Spawners;
using UnityEngine;

namespace GameLogic.UnityComponents
{
	public class PrefabFactory : MonoBehaviour
	{
		private EcsWorld _world;

		public void Init ( EcsWorld world )
		{
			_world = world;
		}

		public void Spawn ( EcsEntity entity, SpawnPrefab spawnData )
		{
			GameObject gameObject = Instantiate (spawnData.Prefab, spawnData.Position, spawnData.Rotation, spawnData.Parent);
			MonoEntity monoEntity = gameObject.GetComponent<MonoEntity> ();

			if (monoEntity != null)
				monoEntity.Link (ref entity);

			MonoEvent monoEvent = gameObject.GetComponent<MonoEvent> ();

			if (monoEvent != null)
				monoEvent.Link (ref entity);
		}
	}
}