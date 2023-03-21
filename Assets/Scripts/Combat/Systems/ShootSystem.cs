using Common;
using Leopotam.Ecs;
using Spawners;
using UnityEngine;

namespace Combat {
    sealed class ShootSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld world = null;
        private EcsFilter<AttackAction, HasRangeWeapon> shootActionFilter = null;

        private float shootForce = 15.0f;

        void IEcsRunSystem.Run () {
            foreach (int i in shootActionFilter) {
                ref EcsEntity entity = ref shootActionFilter.GetEntity (i);
                entity.Del<AttackAction> ();
                if (!entity.Has<GunpointLink> () || !entity.Get<HasRangeWeapon> ().Weapon.IsAlive ()) {
                    Debug.Log ("Shoot attempt failed, the required components are missing on the entity.");
                    return;
                }
                ref EcsEntity weapon = ref entity.Get<HasRangeWeapon> ().Weapon;
                if (weapon.Has<Cooldown> ())
                    return;
                Transform gunpoint = entity.Get<GunpointLink> ().Value;

                weapon.Get<GameObjectLink> ().Value.SetActive (true);
                entity.Get<RangeAttackAnimationFlag> ();

                EcsEntity projectileEntity = world.NewEntity ();
                projectileEntity.Get<SpawnProjectile> () = new SpawnProjectile {
                    Spot = gunpoint,
                    Force = new Vector2 (gunpoint.lossyScale.x, 0) * shootForce,
                    ForceMode = ForceMode2D.Impulse
                };
                projectileEntity.Get<ProjectileFlag> ();                
                projectileEntity.Get<ObjectFromPool> () = new ObjectFromPool { ParentPool = weapon.Get<ProjectilePoolLink> ().Value };
                projectileEntity.Get<Damage> () = new Damage { Value = weapon.Get<Attack> ().Damage };                

                weapon.Get<Cooldown> () = new Cooldown { Value = weapon.Get<CooldownCharacteristic> ().Value };
            }
        }
    }
}