using Leopotam.Ecs;

namespace Common {
    sealed class CameraTargetsSystem :  IEcsRunSystem {
        // auto-injected fields.
        readonly SceneData sceneData = null;
        private EcsFilter<TargetToCameraFlag> cameraTargetFilter = null;

		public void Run () {
            foreach (int i in cameraTargetFilter) {
                ref EcsEntity entity = ref cameraTargetFilter.GetEntity (i);
                entity.Del<TargetToCameraFlag> ();
                if (entity.Has<GameObjectLink> ()) 
                    sceneData.cinemachineBrain.ActiveVirtualCamera.Follow = entity.Get<GameObjectLink> ().Value.transform;
            }
        }
	}
}