using GameLogic.Components.Combat;
using GameLogic.Components.Common;
using GameLogic.Models.Weapons;
using Leopotam.Ecs;
using GameLogic.Components.Spawners;
using UnityEngine;
using GameLogic.Components.Characters;

namespace GameLogic.Systems.Spawners
{
	sealed class SpawnWeaponSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsWorld _world = null;
		private EcsFilter<TakeWeapon> _spawnFilter = null;

		public void Run ()
		{
			foreach (int index in _spawnFilter)
			{
				EcsEntity parent = _spawnFilter.GetEntity (index);
				WeaponData data = parent.Get<TakeWeapon> ().Value;
				Transform linkPoint = parent.Get<HandGrabPointsLink> ().Right;
				EcsEntity weapon = _world.NewEntity ();
				weapon.Get<Owner> () = new Owner { Value = parent };
				weapon.Get<SpawnPrefab> () = new SpawnPrefab
				{
					Prefab = data.Prefab,
					Position = linkPoint.position,
					Rotation = Quaternion.identity,
					Parent = linkPoint
				};
				// Для парного оружия создаем второе оружие и связываем его с основным
				if (data.WeaponTypeByGrab == WeaponTypesByGrab.Paired)
				{
					EcsEntity secondWeapon = _world.NewEntity ();
					linkPoint = parent.Get<HandGrabPointsLink> ().Left;
					secondWeapon.Get<SpawnPrefab> () = new SpawnPrefab
					{
						Prefab = data.Prefab,
						Position = linkPoint.position,
						Rotation = Quaternion.identity,
						Parent = linkPoint
					};
					weapon.Get<SecondWeapon> () = new SecondWeapon { Value = secondWeapon };
				}

				weapon.Get<Attack> () = new Attack { Min = data.MinDamage, Max = data.MaxDamage };
				weapon.Get<CooldownCharacteristic> () = new CooldownCharacteristic { Value = data.Cooldown };
				if (data.WeaponTypeByRange == WeaponTypesByRange.Melee)
					parent.Get<HasMeleeWeapon> ().Weapon = weapon;
				if (data.WeaponTypeByRange == WeaponTypesByRange.Range)
					parent.Get<HasRangeWeapon> ().Weapon = weapon;

				_spawnFilter.GetEntity (index).Del<TakeWeapon> ();
			}
		}
	}
}