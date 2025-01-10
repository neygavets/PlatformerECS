using GameLogic.Components.Common;
using GameLogic.Components.Characters;
using Leopotam.Ecs;
using UnityEngine;
using GameLogic.Components.Combat;
using GameLogic.Models;

namespace GameLogic.Systems.Combat
{
	sealed class DamageSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<DamageEvent> _damageFilter = null;
		private SceneData _sceneData;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _damageFilter)
			{
				DamageEvent damageEvent = _damageFilter.Get1 (i);
				ref EcsEntity targetEntity = ref damageEvent.Target;
				if (!targetEntity.Has<ImmuneToDamageFlag> ())
				{
					targetEntity.Get<Health> ().Current -= damageEvent.Value;
					Debug.Log ($"{targetEntity.Get<GameObjectLink> ().Value.name} получил {damageEvent.Value} урона");
					if (targetEntity.Has<PlayerFlag> ())
						_sceneData.playerInfo.UpdateHealth (targetEntity.Get<Health> ());
					if (targetEntity.Has<EnemyBossFlag> ())
						_sceneData.enemyInfo.UpdateHealth (targetEntity.Get<Health> ());
					if (targetEntity.Get<Health> ().Current <= 0)
						targetEntity.Get<DeadFlag> ();
				}
				_damageFilter.GetEntity (i).Destroy ();
			}
		}
	}
}