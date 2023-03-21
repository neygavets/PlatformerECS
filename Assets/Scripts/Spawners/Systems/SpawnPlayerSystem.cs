using Combat;
using Common;
using Leopotam.Ecs;
using Movements;
using Service;
using UnityEngine;

namespace Spawners {
	public class SpawnPlayerSystem : IEcsInitSystem {
		// auto-injected fields.
		private EcsWorld world = null;
		private StaticData staticData;
		private SceneData sceneData;
		private PreferencesService preferencesService;

		public void Init () {
			EcsEntity player = world.NewEntity ();
			player.Get<SpawnPrefab> () = new SpawnPrefab {
				Prefab = staticData.PlayerPrefab,
				Position = sceneData.spawnPlayerPosition.position,
				Rotation = Quaternion.identity,
				Parent = null
			};
			player.Get<PlayerFlag> ();
			player.Get<Health> () = new Health { Max = preferencesService.LoadPlayerMaxHealth(), Current = preferencesService.LoadPlayerCurrentHealth() };
			player.Get<FreeMovingFlag> ();
			player.Get<HorizontalMovingFlag> ();
			player.Get<Directed> ();
			player.Get<TargetToCameraFlag> ();
			sceneData.playerInfo.LinkEntity (player);
		}
	}
}