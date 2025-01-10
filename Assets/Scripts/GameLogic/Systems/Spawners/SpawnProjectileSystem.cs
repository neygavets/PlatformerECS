using GameLogic.Components.Common;
using GameLogic.UnityComponents;
using Leopotam.Ecs;
using GameLogic.Components.Spawners;
using UnityEngine;

namespace GameLogic.Systems.Spawners
{
	sealed class SpawnProjectileSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<SpawnProjectile> _spawnFilter = null;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _spawnFilter)
			{
				ref EcsEntity entity = ref _spawnFilter.GetEntity (i);
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