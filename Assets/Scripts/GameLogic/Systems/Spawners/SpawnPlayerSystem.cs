using GameLogic.Components.Combat;
using GameLogic.Components.Common;
using Utils;
using Leopotam.Ecs;
using GameLogic.Components.Movements;
using Service;
using UnityEngine;
using GameLogic.Components.Spawners;
using GameLogic.Models;
using GameLogic.Models.Characters;
using GameLogic.Components.Characters;

namespace GameLogic.Systems.Spawners
{
	public class SpawnPlayerSystem : IEcsInitSystem
	{
		// auto-injected fields.
		private EcsWorld _world = null;
		private GameData _staticData;
		private SceneData _sceneData;
		private PreferencesService _preferencesService;

		public void Init ()
		{
			EcsEntity player = _world.NewEntity ();
			PlayerData playerData = _staticData.Player;
			player.Get<SpawnPrefab> () = new SpawnPrefab
			{
				Prefab = playerData.Prefab,
				Position = _sceneData.spawnPlayerPosition.position,
				Rotation = Quaternion.identity,
				Parent = null
			};
			player.Get<PlayerFlag> ();
			player.Get<CharacterCharacteristics> () = new CharacterCharacteristics { Stamina = playerData.Stamina, Strength = playerData.Strength, Agility = playerData.Agility, Intellect = playerData.Intellect };
			player.Get<MeleeAttackPower> () = new MeleeAttackPower { Value = Mechanic—alculator.AttackPower (playerData.Strength, playerData.Agility) };
			player.Get<RangeAttackPower> () = new RangeAttackPower { Value = Mechanic—alculator.AttackPower (playerData.Agility, playerData.Strength) };
			int health = Mechanic—alculator.StaminaToHealth (playerData.Stamina);
			player.Get<Health> () = new Health { Max = health, Current = health };
			if (playerData.Weapon != null)
				player.Get<TakeWeapon> () = new TakeWeapon { Value = playerData.Weapon };
			player.Get<FreeMovingFlag> ();
			player.Get<HorizontalMovingFlag> ();
			player.Get<Directed> ();
			player.Get<TargetToCameraFlag> ();
			_sceneData.playerInfo.LinkEntity (player);
		}
	}
}