using System.Collections.Generic;
using UnityEngine;

namespace OOP {

	public enum AnimationType {
		HorizontalSpeed,
		VerticalSpeed,
		Stealth,
		Duck,
		Jump,
		DoubleJump,
		Fall,
		Dash,
		GrabHold,
		PullUp,
		GrabStair,
		Landing
	}
	public class BaseAnimations : MonoBehaviour {
		[SerializeField] Animator animator;

		private Dictionary<AnimationType, int> animations = new () {
			{ AnimationType.HorizontalSpeed, Animator.StringToHash ("HorizontalSpeed") },
			{ AnimationType.VerticalSpeed, Animator.StringToHash ("VerticalSpeed") },
			{ AnimationType.Stealth, Animator.StringToHash ("isStealth") },
			{ AnimationType.Duck, Animator.StringToHash ("isDuck") },
			{ AnimationType.Jump, Animator.StringToHash ("Jump") },
			{ AnimationType.DoubleJump, Animator.StringToHash ("DoubleJump") },
			{ AnimationType.Fall, Animator.StringToHash ("Falling") },
			{ AnimationType.Dash, Animator.StringToHash ("StartDash") },
			{ AnimationType.GrabHold, Animator.StringToHash ("GrabHold") },
			{ AnimationType.PullUp, Animator.StringToHash ("isPullUp") },
			{ AnimationType.GrabStair, Animator.StringToHash ("isGrabStair") },
			{ AnimationType.Landing, Animator.StringToHash ("Landing") },
		};

		public virtual void Launch ( AnimationType type ) {
			animator.SetTrigger (animations[type]);
		}

		public virtual void Launch ( AnimationType type, float arg ) {
			animator.SetFloat (animations[type], arg);
		}
		public virtual void Launch ( AnimationType type, bool arg ) {
			animator.SetBool (animations[type], arg);
		}

		public float GetCurrentAnimationTime () {
			AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo (0);
			AnimatorClipInfo[] myAnimatorClip = animator.GetCurrentAnimatorClipInfo (0);
			return myAnimatorClip[0].clip.length * animationState.normalizedTime;
		}

	}
}
