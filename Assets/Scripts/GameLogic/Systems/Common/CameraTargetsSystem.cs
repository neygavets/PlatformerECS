using GameLogic.Components.Common;
using GameLogic.Models;
using Leopotam.Ecs;

namespace GameLogic.Systems.Common
{
	sealed class CameraTargetsSystem : IEcsRunSystem
	{
		// auto-injected fields.
		readonly SceneData _sceneData = null;
		private EcsFilter<TargetToCameraFlag> _cameraTargetFilter = null;

		public void Run ()
		{
			foreach (int i in _cameraTargetFilter)
			{
				ref EcsEntity entity = ref _cameraTargetFilter.GetEntity (i);
				entity.Del<TargetToCameraFlag> ();

				if (entity.Has<GameObjectLink> ())
					_sceneData.cinemachineBrain.ActiveVirtualCamera.Follow = entity.Get<GameObjectLink> ().Value.transform;
			}
		}
	}
}