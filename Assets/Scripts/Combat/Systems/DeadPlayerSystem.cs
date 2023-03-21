using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Combat {
    sealed class DeadPlayerSystem : IEcsRunSystem {
        // auto-injected fields.
        private EcsFilter<DeadFlag, PlayerFlag> deadFilter = null;

        void IEcsRunSystem.Run () {
            foreach (int i in deadFilter) {
                ref EcsEntity entity = ref deadFilter.GetEntity (i);
                entity.Del<DeadFlag> ();
                Debug.Log ("Игрок умер");
                //TODO: Обработка смерти игрока
            }
        }
    }
}