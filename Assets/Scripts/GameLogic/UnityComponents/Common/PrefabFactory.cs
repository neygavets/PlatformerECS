using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Spawners {
	public class PrefabFactory : MonoBehaviour {
		private EcsWorld world;

		public void Init ( EcsWorld world ) {
			this.world = world;
		}

		public void Spawn ( EcsEntity entity, SpawnPrefab spawnData ) {
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