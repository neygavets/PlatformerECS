using GameLogic.Components.Combat;
using GameLogic.Components.Common;
using GameLogic.Components.Spawners;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Systems.Combat
{
	sealed class ShootSystem : IEcsRunSystem
	{
		// auto-injected fields.
		readonly EcsWorld _world = null;
		private EcsFilter<AttackAction, HasRangeWeapon> _shootActionFilter = null;

		private const float SHOOT_FORCE = 15.0f;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _shootActionFilter)
			{
				ref EcsEntity entity = ref _shootActionFilter.GetEntity (i);
				entity.Del<AttackAction> ();
				if (!entity.Has<GunpointLink> () || !entity.Get<HasRangeWeapon> ().Weapon.IsAlive ())
				{
					Debug.Log ("Shoot attempt failed, the required components are missing on the entity.");
					return;
				}
				ref EcsEntity weapon = ref entity.Get<HasRangeWeapon> ().Weapon;
				if (weapon.Has<Cooldown> ())
					return;
				Transform gunpoint = entity.Get<GunpointLink> ().Value;

				weapon.Get<GameObjectLink> ().Value.SetActive (true);
				entity.Get<RangeAttackFlag> ();

				EcsEntity projectileEntity = _world.NewEntity ();
				projectileEntity.Get<SpawnProjectile> () = new SpawnProjectile
				{
					Spot = gunpoint,
					Force = new Vector2 (gunpoint.lossyScale.x, 0) * SHOOT_FORCE,
					ForceMode = ForceMode2D.Impulse
				};
				projectileEntity.Get<ProjectileFlag> ();
				projectileEntity.Get<ObjectFromPool> () = new ObjectFromPool { ParentPool = weapon.Get<ProjectilePoolLink> ().Value };
				projectileEntity.Get<Damage> () = new Damage { Value = weapon.Get<Attack> ().Damage };
				projectileEntity.Get<RangeAttackPower> () = new RangeAttackPower { Value = entity.Get<RangeAttackPower> ().Value };

				weapon.Get<Cooldown> () = new Cooldown { Value = weapon.Get<CooldownCharacteristic> ().Value };
			}
		}
	}
}