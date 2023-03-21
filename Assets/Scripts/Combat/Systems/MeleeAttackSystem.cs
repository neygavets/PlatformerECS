using Common;
using Leopotam.Ecs;
using Spawners;
using UnityEngine;

namespace Combat {
	sealed class MeleeAttackSystem : IEcsRunSystem {
		// auto-injected fields.
		readonly EcsWorld world = null;
		private EcsFilter<AttackAction, HasMeleeWeapon> attackActionFilter = null;

		private float widthCheckBox = 0.1f;
		private float attackDistance = 0.5f;

		void IEcsRunSystem.Run () {
			foreach (int i in attackActionFilter) {
				ref EcsEntity entity = ref attackActionFilter.GetEntity (i);
				entity.Del<AttackAction> ();
				if (!entity.Get<HasMeleeWeapon> ().Weapon.IsAlive () || !entity.Has<PhysicalBodySizeLink>()) {
					Debug.Log ("Melee attack attempt failed, the required components are missing on the entity.");
					return;
				}
				ref EcsEntity weapon = ref entity.Get<HasMeleeWeapon> ().Weapon;
				if (weapon.Has<Cooldown> ())
					return;
				weapon.Get<GameObjectLink> ().Value.SetActive (true);
				entity.Get<MeleeAttackAnimationFlag> ();

				LayerMask targetMask = LayerMasks.Player;
				if (entity.Has<PlayerFlag>())
					targetMask = LayerMasks.Enemy;

				Vector2 originPosition = new Vector2 (
					entity.Get<GameObjectLink> ().Value.transform.position.x + (entity.Get<PhysicalBodySizeLink> ().Size.x / 2) * entity.Get<GameObjectLink> ().Value.transform.lossyScale.x,
					entity.Get<GameObjectLink> ().Value.transform.position.y + entity.Get<PhysicalBodySizeLink> ().Size.y / 2
					);
				Vector2 boxSize = new Vector2 (widthCheckBox, entity.Get<PhysicalBodySizeLink> ().Size.y * 0.8f);
				Collider2D targetCollider = Physics2D.BoxCast (originPosition, boxSize, 0, Vector2.right * entity.Get<GameObjectLink> ().Value.transform.lossyScale.x, attackDistance, targetMask).collider;
				if (targetCollider != null) {
					MonoEntity monoEntity = targetCollider.GetComponent<MonoEntity> ();
					if (monoEntity != null && monoEntity.Entity.Has<Health> ())
						world.NewEntity ().Get<DamageEvent> () = new DamageEvent { Target = monoEntity.Entity, Value = weapon.Get<Attack> ().Damage };
				}

				weapon.Get<Cooldown> () = new Cooldown { Value = weapon.Get<CooldownCharacteristic> ().Value };
			}
		}
	}
}