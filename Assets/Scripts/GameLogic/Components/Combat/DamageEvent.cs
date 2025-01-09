using Leopotam.Ecs;

namespace Combat {
    struct DamageEvent {
        public int Value;
        public EcsEntity Target;
    }
}