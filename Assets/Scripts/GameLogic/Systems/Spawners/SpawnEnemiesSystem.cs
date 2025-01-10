using GameLogic.Components.Combat;
using GameLogic.Components.Characters;
using Leopotam.Ecs;
using GameLogic.Components.Movements;
using UnityEngine;
using Utils;
using GameLogic.UnityComponents;
using GameLogic.Components.Spawners;
using GameLogic.Models;

namespace GameLogic.Systems.Spawners
{
	sealed class SpawnEnemiesSystem : IEcsInitSystem
	{
		readonly EcsWorld _world = null;
		private SceneData _sceneData;

		public void Init ()
		{
			if (_sceneData.spawnEnemyPoints.Length == 0)
				return;

			foreach (EnemyPoint enemyPoint in _sceneData.spawnEnemyPoints)
			{
				EcsEntity enemy = _world.NewEntity ();
				enemy.Get<SpawnPrefab> () = new SpawnPrefab
				{
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
				if (enemyPoint.Data.IsBoss)
				{
					enemy.Get<EnemyBossFlag> ();
					_sceneData.enemyInfo.LinkEntity (enemy);
				}
			}
		}
	}
}