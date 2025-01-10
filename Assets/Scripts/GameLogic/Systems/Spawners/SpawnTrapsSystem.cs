using GameLogic.Components.Combat;
using GameLogic.Components.Common;
using GameLogic.UnityComponents;
using Leopotam.Ecs;
using GameLogic.Components.Spawners;
using UnityEngine;
using GameLogic.Models;
using GameLogic.Components.Traps;

namespace GameLogic.Systems.Spawners
{
	sealed class SpawnTrapsSystem : IEcsInitSystem
	{
		// auto-injected fields.
		readonly EcsWorld _world = null;
		private SceneData _sceneData;

		public void Init ()
		{
			if (_sceneData.spawnTrapPoints.Length == 0)
				return;
			foreach (TrapPoint trapPoint in _sceneData.spawnTrapPoints)
			{
				EcsEntity trap = _world.NewEntity ();
				trap.Get<SpawnPrefab> () = new SpawnPrefab
				{
					Prefab = trapPoint.Data.Prefab,
					Position = trapPoint.transform.position,
					Rotation = Quaternion.identity,
					Parent = null
				};
				trap.Get<Damage> () = new Damage { Value = trapPoint.Data.Damage };
				trap.Get<CooldownCharacteristic> () = new CooldownCharacteristic { Value = trapPoint.Data.Cooldown };
				trap.Get<TrapFlag> ();
				if (trapPoint.Data.IsSingleUse)
					trap.Get<SingleUseFlag> ();
			}
		}
	}
}