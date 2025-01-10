using GameLogic.Components.Characters;
using GameLogic.Components.Combat;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Systems.Characters
{
	sealed class DeadPlayerSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<DeadFlag, PlayerFlag> _deadFilter = null;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _deadFilter)
			{
				ref EcsEntity entity = ref _deadFilter.GetEntity (i);
				entity.Del<DeadFlag> ();
				Debug.Log ("Игрок умер");
				//TODO: Обработка смерти игрока
			}
		}
	}
}