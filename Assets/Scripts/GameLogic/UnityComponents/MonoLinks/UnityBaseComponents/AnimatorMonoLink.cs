using Leopotam.Ecs;
using UnityEngine;
using Common;

namespace GameLogic.UnityComponents
{
	public class AnimatorMonoLink : MonoLink<AnimatorLink>
	{
		[SerializeField]
		private Animator _animator;

		public override void Make ( ref EcsEntity entity )
		{
			entity.Get<AnimatorLink> () = new AnimatorLink
			{
				Value = _animator
			};
		}
	}
}