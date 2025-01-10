using GameLogic.Components.Common;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Systems.Common
{
	sealed class CooldownSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<Cooldown> _cooldownFilter = null;

		void IEcsRunSystem.Run ()
		{
			foreach (int index in _cooldownFilter)
			{
				float cooldownTime = _cooldownFilter.Get1 (index).Value;
				cooldownTime -= Time.deltaTime;

				if (cooldownTime <= 0)
				{
					_cooldownFilter.GetEntity (index).Del<Cooldown> ();
				}					
				else
				{
					_cooldownFilter.Get1 (index).Value = cooldownTime;
				}					
			}
		}
	}
}