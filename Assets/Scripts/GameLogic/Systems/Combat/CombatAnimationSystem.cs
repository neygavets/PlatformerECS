using GameLogic.Components.Combat;
using GameLogic.Components.Common;
using Leopotam.Ecs;
using Utils;

namespace GameLogic.Systems.Combat
{
	sealed class CombatAnimationSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<RangeAttackFlag> _rangeAttackFilter = null;
		private EcsFilter<MeleeAttackFlag> _meleeAttackFilter = null;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _rangeAttackFilter)
			{
				_rangeAttackFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.RangeAttack);
				_rangeAttackFilter.GetEntity (i).Del<RangeAttackFlag> ();
			}
			foreach (int i in _meleeAttackFilter)
			{
				_meleeAttackFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.MeleeAttack);
				_meleeAttackFilter.GetEntity (i).Del<MeleeAttackFlag> ();
			}
		}
	}
}