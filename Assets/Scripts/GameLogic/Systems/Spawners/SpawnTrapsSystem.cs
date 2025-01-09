using Combat;
using Common;
using GameLogic.UnityComponents;
using Leopotam.Ecs;
using Traps;
using UnityEngine;

namespace Spawners {
    sealed class SpawnTrapsSystem : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld world = null;
        private SceneData sceneData;

        public void Init () {
			if (sceneData.spawnTrapPoints.Length == 0)
				return;
			foreach (TrapPoint trapPoint in sceneData.spawnTrapPoints) {
				EcsEntity trap = world.NewEntity ();
				trap.Get<SpawnPrefab> () = new SpawnPrefab {
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