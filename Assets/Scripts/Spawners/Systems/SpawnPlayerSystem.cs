using Characters;
using Combat;
using Common;
using Utils;
using Leopotam.Ecs;
using Movements;
using Service;
using UnityEngine;

namespace Spawners {
	public class SpawnPlayerSystem : IEcsInitSystem {
		// auto-injected fields.
		private EcsWorld world = null;
		private GameData staticData;
		private SceneData sceneData;
		private PreferencesService preferencesService;

		public void Init () {
			EcsEntity player = world.NewEntity ();
			PlayerData playerData = staticData.Player;
			player.Get<SpawnPrefab> () = new SpawnPrefab {
				Prefab = playerData.Prefab,
				Position = sceneData.spawnPlayerPosition.position,
				Rotation = Quaternion.identity,
				Parent = null
			};
			player.Get<PlayerFlag> ();
			player.Get<CharacterCharacteristics> () = new CharacterCharacteristics { Stamina = playerData.Stamina, Strength = playerData.Strength, Agility = playerData.Agility, Intellect = playerData.Intellect };
			player.Get<MeleeAttackPower> () = new MeleeAttackPower { Value = Mechanic—alculator.AttackPower(playerData.Strength, playerData.Agility) };
			player.Get<RangeAttackPower> () = new RangeAttackPower { Value = Mechanic—alculator.AttackPower(playerData.Agility, playerData.Strength) };
			int health = Mechanic—alculator.StaminaToHealth (playerData.Stamina);
			player.Get<Health> () = new Health { Max = health, Current = health };
			if (playerData.Weapon != null)
				player.Get<TakeWeapon> () = new TakeWeapon { Value = playerData.Weapon };
			player.Get<FreeMovingFlag> ();
			player.Get<HorizontalMovingFlag> ();
			player.Get<Directed> ();
			player.Get<TargetToCameraFlag> ();
			sceneData.playerInfo.LinkEntity (player);
		}
	}
}