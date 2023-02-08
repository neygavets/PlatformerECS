using Common;
using Leopotam.Ecs;
using System;
using UnityEngine;

namespace Movements {
    [Obsolete ("GravityScaleSystem is deprecated, please don't use it.", true)]
    sealed class GravityScaleSystem : IEcsRunSystem {
        // auto-injected fields.
        private EcsFilter<FreeMovingFlag, Rigidbody2DLink, MotionConfigLink> movableBodyFilter = null;

        void IEcsRunSystem.Run () {
            foreach (int i in movableBodyFilter) {
                ref Rigidbody2D body = ref movableBodyFilter.Get2 (i).Value;
                ref MotionConfig config = ref movableBodyFilter.Get3 (i).Value;

                if (movableBodyFilter.GetEntity (i).Has<GroundedFlag>()) {
                    body.gravityScale = config.GroundedGravityScale;
                } else {
                    // Если тело не на земле, установить модификатор силы тяжести для движения вверх или для падения
                    body.gravityScale = body.velocity.y > 0.0f ? config.JumpGravityScale : config.FallGravityScale;
                }
            }
        }
    }
}