using GameLogic.Components.Combat;
using GameLogic.Components.Common;
using GameLogic.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace GameLogic.Systems.Combat
{
	sealed class ProjectileHitSystem : IEcsRunSystem
	{
		// auto-injected fields.
		readonly EcsWorld _world = null;
		private EcsFilter<ProjectileFlag, OnTriggerEnterEvent> _hitFilter = null;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _hitFilter)
			{
				ref EcsEntity projectile = ref _hitFilter.GetEntity (i);
				GameObject projectileObject = projectile.Get<GameObjectLink> ().Value;
				projectile.Get<Rigidbody2DLink> ().Value.velocity = Vector2.zero;
				MonoEntity targetMonoEntity = _hitFilter.Get2 (i).Value.GetComponent<MonoEntity> ();

				if (targetMonoEntity != null && targetMonoEntity.Entity.Has<Health> ())
				{
					_world.NewEntity ().Get<DamageEvent> () = new DamageEvent
					{
						Target = targetMonoEntity.Entity,
						Value = Mechanic—alculator.Damage (
							projectile.Get<RangeAttackPower> ().Value,
							projectile.Get<Damage> ().Value,
							targetMonoEntity.Entity.Get<Armor> ().Value)
					};
				}

				if (projectile.Has<ObjectFromPool> ())
				{
					projectile.Get<ObjectFromPool> ().ParentPool.ReturnObject (projectileObject);
				}					
				else
				{
					Object.Destroy (projectileObject);
				}
					
				projectile.Destroy ();
			}
		}
	}
}