using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Combat {
    sealed class CombatAnimationSystem : IEcsRunSystem {
        // auto-injected fields.
        private EcsFilter<RangeAttackAnimationFlag> rangeAttackFilter = null;
        private EcsFilter<MeleeAttackAnimationFlag> meleeAttackFilter = null;

        void IEcsRunSystem.Run () {
            foreach (int i in rangeAttackFilter) {
                rangeAttackFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.RangeAttack);
                rangeAttackFilter.GetEntity (i).Del<RangeAttackAnimationFlag> ();
            }
            foreach (int i in meleeAttackFilter) {
                meleeAttackFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.MeleeAttack);
                meleeAttackFilter.GetEntity (i).Del<MeleeAttackAnimationFlag> ();
            }
        }
    }
}