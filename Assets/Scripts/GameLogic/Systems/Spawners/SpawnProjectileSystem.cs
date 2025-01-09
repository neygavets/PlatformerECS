using Common;
using GameLogic.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Spawners {
	sealed class SpawnProjectileSystem : IEcsRunSystem {
		// auto-injected fields.
		private EcsFilter<SpawnProjectile> spawnFilter = null;

		void IEcsRunSystem.Run () {
			foreach (int i in spawnFilter) {
				ref EcsEntity entity = ref spawnFilter.GetEntity (i);				
				SpawnProjectile spawnData = entity.Get<SpawnProjectile> ();
				GameObject projectile = entity.Get<ObjectFromPool> ().ParentPool.GetPooledObject ();

				projectile.transform.SetPositionAndRotation (spawnData.Spot.position, Quaternion.identity);
				projectile.GetComponent<SpriteRenderer> ().flipX = spawnData.Spot.lossyScale.x > 0;
				projectile.SetActive (true);
				projectile.GetComponent<Rigidbody2D> ().AddForce (spawnData.Force, spawnData.ForceMode);

				MonoEntity monoEntity = projectile.GetComponent<MonoEntity> ();
				if (monoEntity != null)
					monoEntity.Link (ref entity);

				entity.Del<SpawnProjectile> ();
			}
		}
	}
}