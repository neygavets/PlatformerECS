using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Movements {
    sealed class DirectionSystem : IEcsRunSystem {
        // auto-injected fields.
        private EcsFilter<Directed, Rigidbody2DLink> directedBodyFilter = null;

        private readonly Vector3 flippedScale = new (-1, 1, 1);
        private readonly float minFlipSpeed = 0.1f; // Минимальная скорость движения, при которой тело развернется в направлении этого движения

        void IEcsRunSystem.Run () {
            foreach (int i in directedBodyFilter) {
                ref Rigidbody2D body = ref directedBodyFilter.Get2 (i).Value;
                ref bool isFlipped = ref directedBodyFilter.Get1 (i).isFlipped;
                if (body.velocity.x > minFlipSpeed && isFlipped) {
                    isFlipped = false;
                    body.transform.localScale = Vector3.one;
                }
                if (body.velocity.x < -minFlipSpeed && !isFlipped) {
                    isFlipped = true;
                    body.transform.localScale = flippedScale;
                }
            }
        }
    }
}