using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Movements {
	sealed class MoveAnimationSystem : IEcsRunSystem {
		// auto-injected fields.
		private EcsFilter<HorizontalSpeedAnimation> horizontalSpeedFilter = null;
		private EcsFilter<VerticalSpeedAnimation> verticalSpeedFilter = null;
		private EcsFilter<DuckEnterAnimationFlag> duckEnterFilter = null;
		private EcsFilter<DuckExitAnimationFlag> duckExitFilter = null;
		private EcsFilter<JumpAnimationFlag> jumpFilter = null;
		private EcsFilter<FallingAnimationFlag> fallingFilter = null;
		private EcsFilter<DashAnimationFlag> dashFilter = null;
		private EcsFilter<GrabLedgeAnimationFlag> grabLedgeFilter = null;
		private EcsFilter<GrabStairEnterAnimationFlag> grabStairEnterFilter = null;
		private EcsFilter<GrabStairExitAnimationFlag> grabStairExitFilter = null;
		private EcsFilter<PullUpAnimationFlag> pullUpFilter = null;
		private EcsFilter<LandingAnimationFlag> landingFilter = null;

		void IEcsRunSystem.Run () {
			foreach (int i in horizontalSpeedFilter) {
				Animator animator = horizontalSpeedFilter.GetEntity (i).Get<AnimatorLink> ().Value;
				animator.SetFloat (AnimationLib.HorizontalSpeed, Mathf.Abs (horizontalSpeedFilter.Get1 (i).Value));
			}
			foreach (int i in verticalSpeedFilter) {
				Animator animator = verticalSpeedFilter.GetEntity (i).Get<AnimatorLink> ().Value;
				animator.SetFloat (AnimationLib.VerticalSpeed, verticalSpeedFilter.Get1 (i).Value);
			}
			foreach (int i in duckEnterFilter) {
				duckEnterFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetBool (AnimationLib.Duck, true);
				duckEnterFilter.GetEntity (i).Del<DuckEnterAnimationFlag> ();
			}
			foreach (int i in duckExitFilter) {
				duckExitFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetBool (AnimationLib.Duck, false);
				duckExitFilter.GetEntity (i).Del<DuckExitAnimationFlag> ();
			}
			foreach (int i in jumpFilter) {
				jumpFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.Jump);
				jumpFilter.GetEntity (i).Del<JumpAnimationFlag> ();
			}
			foreach (int i in fallingFilter) {
				fallingFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.Falling);
				fallingFilter.GetEntity (i).Del<FallingAnimationFlag> ();
			}
			foreach (int i in dashFilter) {
				Debug.Log ("Анимация рывка пока не реализована");
			}
			foreach (int i in grabLedgeFilter) {
				grabLedgeFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.GrabLedge);
				grabLedgeFilter.GetEntity (i).Del<GrabLedgeAnimationFlag> ();
			}
			foreach (int i in grabStairEnterFilter) {
				grabStairEnterFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetBool (AnimationLib.GrabStair, true);
				grabStairEnterFilter.GetEntity (i).Del<GrabStairEnterAnimationFlag> ();
			}
			foreach (int i in grabStairExitFilter) {
				grabStairExitFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetBool (AnimationLib.GrabStair, false);
				grabStairExitFilter.GetEntity (i).Del<GrabStairExitAnimationFlag> ();
			}
			foreach (int i in pullUpFilter) {
				pullUpFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.PullUp);
				pullUpFilter.GetEntity (i).Del<PullUpAnimationFlag> ();
			}
			foreach (int i in landingFilter) {
				landingFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.Landing);
				landingFilter.GetEntity (i).Del<LandingAnimationFlag> ();
			}
		}
	}
}