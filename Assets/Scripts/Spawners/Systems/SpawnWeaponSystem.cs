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
				ref EcsEntity parentEntity = ref spawnFilter.GetEntity (index);
				WeaponData data = parentEntity.Get<TakeWeapon> ().Data;
				Transform linkPoint = parentEntity.Get<TakeWeapon> ().LinkPoint;
				EcsEntity weapon = world.NewEntity ();
				weapon.Get<Owner> () = new Owner { Value = parentEntity };
				weapon.Get<SpawnPrefab> () = new SpawnPrefab {
					Prefab = data.Prefab,
					Position = linkPoint.position,
					Rotation = Quaternion.identity,
					Parent = linkPoint
				};
				weapon.Get<Attack> () = new Attack { Min = data.MinDamage, Max = data.MaxDamage };
				weapon.Get<CooldownCharacteristic> () = new CooldownCharacteristic { Value = data.Cooldown };
				if (data.WeaponType == WeaponTypes.Melee)
					parentEntity.Get<HasMeleeWeapon> ().Weapon = weapon;
				if (data.WeaponType == WeaponTypes.Range)
					parentEntity.Get<HasRangeWeapon> ().Weapon = weapon;
				parentEntity.Del<TakeWeapon> ();
			}
		}
	}
}