using Leopotam.Ecs;

namespace EnemyAI {
    sealed class SelectionSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private EcsFilter<Aggression, Cowardice> filter = null;

        void IEcsRunSystem.Run () {
            foreach (int i in filter) {
                ref EcsEntity entity = ref filter.GetEntity (i);
                // Тут будем в зависимости от уровня трусости/агрессии принимать решение, что делать
            }
        }
    }
}