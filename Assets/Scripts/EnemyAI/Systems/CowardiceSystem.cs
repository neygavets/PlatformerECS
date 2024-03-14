using Characters;
using Leopotam.Ecs;

namespace EnemyAI {
    sealed class CowardiceSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private EcsFilter<EnemyFlag> filter = null;

        void IEcsRunSystem.Run () {
            foreach (int i in filter) {
                ref EcsEntity entity = ref filter.GetEntity (i);
                // “ут будем увеличивать или уменьшать трусость
            }
        }
    }
}