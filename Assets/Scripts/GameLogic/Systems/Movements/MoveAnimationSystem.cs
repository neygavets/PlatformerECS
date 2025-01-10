using GameLogic.Components.Common;
using Leopotam.Ecs;
using GameLogic.Components.Movements;
using UnityEngine;
using Utils;

namespace GameLogic.Systems.Movements
{
	sealed class MoveAnimationSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<HorizontalSpeedAnimation> _horizontalSpeedFilter = null;
		private EcsFilter<VerticalSpeedAnimation> _verticalSpeedFilter = null;
		private EcsFilter<DuckEnterAnimationFlag> _duckEnterFilter = null;
		private EcsFilter<DuckExitAnimationFlag> _duckExitFilter = null;
		private EcsFilter<JumpAnimationFlag> _jumpFilter = null;
		private EcsFilter<FallingAnimationFlag> _fallingFilter = null;
		private EcsFilter<DashAnimationFlag> _dashFilter = null;
		private EcsFilter<GrabLedgeAnimationFlag> _grabLedgeFilter = null;
		private EcsFilter<GrabStairEnterAnimationFlag> _grabStairEnterFilter = null;
		private EcsFilter<GrabStairExitAnimationFlag> _grabStairExitFilter = null;
		private EcsFilter<PullUpAnimationFlag> _pullUpFilter = null;
		private EcsFilter<LandingAnimationFlag> _landingFilter = null;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _horizontalSpeedFilter)
			{
				Animator animator = _horizontalSpeedFilter.GetEntity (i).Get<AnimatorLink> ().Value;
				animator.SetFloat (AnimationLib.HorizontalSpeed, Mathf.Abs (_horizontalSpeedFilter.Get1 (i).Value));
			}
			foreach (int i in _verticalSpeedFilter)
			{
				Animator animator = _verticalSpeedFilter.GetEntity (i).Get<AnimatorLink> ().Value;
				animator.SetFloat (AnimationLib.VerticalSpeed, _verticalSpeedFilter.Get1 (i).Value);
			}
			foreach (int i in _duckEnterFilter)
			{
				_duckEnterFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetBool (AnimationLib.Duck, true);
				_duckEnterFilter.GetEntity (i).Del<DuckEnterAnimationFlag> ();
			}
			foreach (int i in _duckExitFilter)
			{
				_duckExitFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetBool (AnimationLib.Duck, false);
				_duckExitFilter.GetEntity (i).Del<DuckExitAnimationFlag> ();
			}
			foreach (int i in _jumpFilter)
			{
				_jumpFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.Jump);
				_jumpFilter.GetEntity (i).Del<JumpAnimationFlag> ();
			}
			foreach (int i in _fallingFilter)
			{
				_fallingFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.Falling);
				_fallingFilter.GetEntity (i).Del<FallingAnimationFlag> ();
			}
			foreach (int i in _dashFilter)
			{
				Debug.Log ("Анимация рывка пока не реализована");
			}
			foreach (int i in _grabLedgeFilter)
			{
				_grabLedgeFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.GrabLedge);
				_grabLedgeFilter.GetEntity (i).Del<GrabLedgeAnimationFlag> ();
			}
			foreach (int i in _grabStairEnterFilter)
			{
				_grabStairEnterFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetBool (AnimationLib.GrabStair, true);
				_grabStairEnterFilter.GetEntity (i).Del<GrabStairEnterAnimationFlag> ();
			}
			foreach (int i in _grabStairExitFilter)
			{
				_grabStairExitFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetBool (AnimationLib.GrabStair, false);
				_grabStairExitFilter.GetEntity (i).Del<GrabStairExitAnimationFlag> ();
			}
			foreach (int i in _pullUpFilter)
			{
				_pullUpFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.PullUp);
				_pullUpFilter.GetEntity (i).Del<PullUpAnimationFlag> ();
			}
			foreach (int i in _landingFilter)
			{
				_landingFilter.GetEntity (i).Get<AnimatorLink> ().Value.SetTrigger (AnimationLib.Landing);
				_landingFilter.GetEntity (i).Del<LandingAnimationFlag> ();
			}
		}
	}
}