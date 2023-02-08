using Common;
using Leopotam.Ecs;
using Movements;
using UnityEngine;

namespace Spawners {
	public class SpawnPlayer : IEcsInitSystem {
		private EcsWorld world = null;
		private StaticData staticData;
		private SceneData sceneData;

		public void Init () {
			EcsEntity player = world.NewEntity ();
			player.Get<SpawnPrefab> () = new SpawnPrefab {
				Prefab = staticData.PlayerPrefab,
				Position = sceneData.SpawnPlayerPosition.position,
				Rotation = Quaternion.identity,
				Parent = null
			};
			player.Get<PlayerFlag> ();
			player.Get<FreeMovingFlag> ();
			player.Get<HorizontalMovingFlag> ();
			player.Get<Directed> ();
			player.Get<TargetToCameraFlag> ();
		}
	}
}