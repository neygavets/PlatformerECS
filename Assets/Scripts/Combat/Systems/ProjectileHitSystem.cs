using Common;
using Leopotam.Ecs;
using UnityEngine;

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
                MonoEntity monoEntity = hitFilter.Get2 (i).Value.GetComponent<MonoEntity> ();

                if (monoEntity != null && monoEntity.Entity.Has<Health> ())
                    world.NewEntity ().Get<DamageEvent> () = new DamageEvent { Target = monoEntity.Entity, Value = projectile.Get<Damage>().Value};


                if (projectile.Has<ObjectFromPool> ())
                    projectile.Get<ObjectFromPool> ().ParentPool.ReturnObject (projectileObject);
                else
					GameObject.Destroy (projectileObject);
                projectile.Destroy ();
            }
        }
    }
}