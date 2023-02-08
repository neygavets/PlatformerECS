using Common;
using Leopotam.Ecs;
using Utils;

namespace Movements {
    sealed class CheckGroundSystem : IEcsRunSystem {
        // auto-injected fields.
        private EcsFilter<FreeMovingFlag, Rigidbody2DLink, PhysicalBodySizeLink, MotionConfigLink> checkedFilter = null;

        void IEcsRunSystem.Run () {
            foreach (int i in checkedFilter) {
                ref EcsEntity entity = ref checkedFilter.GetEntity (i);
                bool isGrounded = ObstacleChecker.CheckUnderfoot (checkedFilter.Get2 (i).Value.transform.position, checkedFilter.Get3 (i).Size.x, LayerMasks.Ground);                

                if (isGrounded) {
                    entity.Del<FallingFlag> ();
                    if (!entity.Has<GroundedFlag> ()) {
                        checkedFilter.Get2 (i).Value.gravityScale = checkedFilter.Get4 (i).Value.GroundedGravityScale;
                        entity.Get<GroundedFlag> ();
                        entity.Get<LandingAnimationFlag> ();
                    }                     
                } else {
                    entity.Del<GroundedFlag> ();
                }
            }
        }
    }
}