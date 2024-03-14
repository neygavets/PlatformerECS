using Combat;
using Common;
using Characters;
using Leopotam.Ecs;
using Movements;
using UnityEngine;
using Utils;

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
				enemy.Get<Directed> ();
				enemy.Get<MeleeAttackPower> () = new MeleeAttackPower { Value = Mechanic—alculator.AttackPower (enemyPoint.Data.Strength, enemyPoint.Data.Agility) };
				enemy.Get<RangeAttackPower> () = new RangeAttackPower { Value = Mechanic—alculator.AttackPower (enemyPoint.Data.Agility, enemyPoint.Data.Strength) };
				int health = Mechanic—alculator.StaminaToHealth (enemyPoint.Data.Stamina);
				enemy.Get<Health> () = new Health { Current = health, Max = health };
				enemy.Get<Armor> ().Value = enemyPoint.Data.Armor;
				if (enemyPoint.Data.Weapon != null)
					enemy.Get<TakeWeapon> () = new TakeWeapon { Value = enemyPoint.Data.Weapon };
				if (enemyPoint.Data.IsBoss) {
					enemy.Get<EnemyBossFlag> ();
					sceneData.enemyInfo.LinkEntity (enemy);
				}
			}			
		}
    }
}