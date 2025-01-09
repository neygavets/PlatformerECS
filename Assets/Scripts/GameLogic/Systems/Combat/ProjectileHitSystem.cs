using Common;
using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace Combat {
    sealed class ProjectileHitSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld world = null;
        private EcsFilter<ProjectileFlag, OnTriggerEnterEvent> hitFilter = null;

        void IEcsRunSystem.Run () {
            foreach (int i in hitFilter) {
                ref EcsEntity projectile = ref hitFilter.GetEntity (i);
                GameObject projectileObject = projectile.Get<GameObjectLink> ().Value;
                projectile.Get<Rigidbody2DLink> ().Value.velocity = Vector2.zero;
                MonoEntity targetMonoEntity = hitFilter.Get2 (i).Value.GetComponent<MonoEntity> ();

                if (targetMonoEntity != null && targetMonoEntity.Entity.Has<Health> ())
                    world.NewEntity ().Get<DamageEvent> () = new DamageEvent {
                        Target = targetMonoEntity.Entity,
                        Value = Mechanic—alculator.Damage (projectile.Get<RangeAttackPower> ().Value, projectile.Get<Damage> ().Value, targetMonoEntity.Entity.Get<Armor> ().Value)
                    };
                if (projectile.Has<ObjectFromPool> ())
                    projectile.Get<ObjectFromPool> ().ParentPool.ReturnObject (projectileObject);
                else
					GameObject.Destroy (projectileObject);
                projectile.Destroy ();
            }
        }
    }
}