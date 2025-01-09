using Common;
using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace Combat {
    sealed class CombatAnimationSystem : IEcsRunSystem {
        // auto-injected fields.
        private EcsFilter<RangeAttackFlag> rangeAttackFilter = null;
        private EcsFilter<MeleeAttackFlag> meleeAttackFilter = null;

        void IEcsRunSystem.Run () {
            foreach (int i in rangeAttackFilter) {
                rangeAttackFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.RangeAttack);
                rangeAttackFilter.GetEntity (i).Del<RangeAttackFlag> ();
            }
            foreach (int i in meleeAttackFilter) {
                meleeAttackFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.MeleeAttack);
                meleeAttackFilter.GetEntity (i).Del<MeleeAttackFlag> ();
            }
        }
    }
}