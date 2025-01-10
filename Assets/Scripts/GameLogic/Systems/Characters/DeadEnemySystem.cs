using GameLogic.Components.Characters;
using GameLogic.Components.Combat;
using GameLogic.Components.Common;
using GameLogic.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.Systems.Characters
{
	sealed class DeadEnemySystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<DeadFlag, EnemyFlag> _deadFilter = null;
		private SceneData _sceneData;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _deadFilter)
			{
				ref EcsEntity entity = ref _deadFilter.GetEntity (i);
				entity.Del<DeadFlag> ();

				//TODO: Обработка смерти врага
				Debug.Log ("Враг повержен: " + entity.Get<GameObjectLink> ().Value.name);

				Object.Destroy (entity.Get<GameObjectLink> ().Value);
				entity.Destroy ();
			}
		}
	}
}