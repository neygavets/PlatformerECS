using Combat;
using Enemies;
using Leopotam.Ecs;
using Movements;
using UnityEngine;

namespace Spawners {
    sealed class SpawnEnemiesSystem : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld world = null;
        private SceneData sceneData;

        public void Init () {
			if (sceneData.spawnEnemyPoints.Length == 0)
				return;
			foreach (EnemyPoint enemyPoint in sceneData.spawnEnemyPoints) {
				EcsEntity enemy = world.NewEntity ();
				enemy.Get<SpawnPrefab> () = new SpawnPrefab {
					Prefab = enemyPoint.Data.Prefab,
					Position = enemyPoint.transform.position,
					Rotation = Quaternion.identity,
					Parent = null
				};
				enemy.Get<EnemyFlag> ();									
				enemy.Get<Health> () = new Health { Current = enemyPoint.Data.Health, Max = enemyPoint.Data.Health };
				enemy.Get<Directed> ();
				if (enemyPoint.Data.IsBoss) {
					enemy.Get<EnemyBossFlag> ();
					sceneData.enemyInfo.LinkEntity (enemy);
				}
			}			
		}
    }
}