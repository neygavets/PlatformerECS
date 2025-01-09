using Combat;
using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Spawners {
    sealed class SpawnWeaponSystem : IEcsRunSystem {
        // auto-injected fields.
        private EcsWorld world = null;
		private EcsFilter<TakeWeapon> spawnFilter = null;

		public void Run () {
			foreach (int index in spawnFilter) {
				EcsEntity parent = spawnFilter.GetEntity (index);
				WeaponData data = parent.Get<TakeWeapon>().Value;				
				Transform linkPoint = parent.Get<HandGrabPointsLink> ().Right;
				EcsEntity weapon = world.NewEntity ();
				weapon.Get<Owner> () = new Owner { Value = parent };
				weapon.Get<SpawnPrefab> () = new SpawnPrefab {
					Prefab = data.Prefab,
					Position = linkPoint.position,
					Rotation = Quaternion.identity,
					Parent = linkPoint
				};
				// Для парного оружия создаем второе оружие и связываем его с основным
				if (data.WeaponTypeByGrab == WeaponTypesByGrab.Paired) {
					EcsEntity secondWeapon = world.NewEntity ();
					linkPoint = parent.Get<HandGrabPointsLink> ().Left;
					secondWeapon.Get<SpawnPrefab> () = new SpawnPrefab {
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

				spawnFilter.GetEntity(index).Del<TakeWeapon> ();
			}
		}
	}
}