using Leopotam.Ecs;
using UnityEngine;

namespace Common {
	public class AnimatorMonoLink : MonoLink<AnimatorLink> {
		[SerializeField] Animator animator;

		public override void Make ( ref EcsEntity entity ) {
			entity.Get<AnimatorLink> () = new AnimatorLink {
				Value = animator
			};
		}
	}
}