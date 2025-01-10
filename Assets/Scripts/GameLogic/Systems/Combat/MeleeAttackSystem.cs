using GameLogic.Components.Characters;
using GameLogic.Components.Combat;
using GameLogic.Components.Common;
using GameLogic.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace GameLogic.Systems.Combat
{
	sealed class MeleeAttackSystem : IEcsRunSystem
	{
		// auto-injected fields.
		readonly EcsWorld _world = null;
		private EcsFilter<AttackAction, HasMeleeWeapon> _attackActionFilter = null;

		private const float WIDTH_CHECKBOX = 0.1f;
		private const float HEIGHT_CHECKBOX_MODIFIER = 0.8f;
		private const float ATTACK_DISTANCE = 0.5f;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _attackActionFilter)
			{
				ref EcsEntity entity = ref _attackActionFilter.GetEntity (i);
				entity.Del<AttackAction> ();
				if (!entity.Get<HasMeleeWeapon> ().Weapon.IsAlive () || !entity.Has<PhysicalBodySizeLink> ())
				{
					Debug.Log ("Melee attack attempt failed, the required components are missing on the entity.");
					return;
				}

				ref EcsEntity weapon = ref entity.Get<HasMeleeWeapon> ().Weapon;
				if (weapon.Has<Cooldown> ())
					return;

				weapon.Get<GameObjectLink> ().Value.SetActive (true);
				entity.Get<MeleeAttackFlag> ();

				LayerMask targetMask = LayerMasks.Player;
				if (entity.Has<PlayerFlag> ())
					targetMask = LayerMasks.Enemy;

				Vector2 originPosition = new Vector2 (
					entity.Get<GameObjectLink> ().Value.transform.position.x + (entity.Get<PhysicalBodySizeLink> ().Size.x / 2) * entity.Get<GameObjectLink> ().Value.transform.lossyScale.x,
					entity.Get<GameObjectLink> ().Value.transform.position.y + entity.Get<PhysicalBodySizeLink> ().Size.y / 2
					);
				Vector2 boxSize = new Vector2 (WIDTH_CHECKBOX, entity.Get<PhysicalBodySizeLink> ().Size.y * HEIGHT_CHECKBOX_MODIFIER);
				Collider2D targetCollider = Physics2D.BoxCast (originPosition, boxSize, 0, Vector2.right * entity.Get<GameObjectLink> ().Value.transform.lossyScale.x, ATTACK_DISTANCE, targetMask).collider;

				if (targetCollider != null)
				{
					MonoEntity targetMonoEntity = targetCollider.GetComponent<MonoEntity> ();
					if (targetMonoEntity != null && targetMonoEntity.Entity.Has<Health> ())
						_world.NewEntity ().Get<DamageEvent> () = new DamageEvent
						{
							Target = targetMonoEntity.Entity,
							Value = Mechanic—alculator.Damage (entity.Get<MeleeAttackPower> ().Value, weapon.Get<Attack> ().Damage, targetMonoEntity.Entity.Get<Armor> ().Value)
						};
				}

				weapon.Get<Cooldown> () = new Cooldown { Value = weapon.Get<CooldownCharacteristic> ().Value };
			}
		}
	}
}