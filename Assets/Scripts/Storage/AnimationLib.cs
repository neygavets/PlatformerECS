using UnityEngine;

public static class AnimationLib {
	public static int HorizontalSpeed = Animator.StringToHash ("HorizontalSpeed");
	public static int VerticalSpeed = Animator.StringToHash ("VerticalSpeed");
	public static int Duck = Animator.StringToHash ("isDuck");
	public static int Jump = Animator.StringToHash ("Jump");
	public static int Falling = Animator.StringToHash ("Falling");
	public static int Dash = Animator.StringToHash ("StartDash");
	public static int GrabLedge = Animator.StringToHash ("GrabHold");
	public static int PullUp = Animator.StringToHash ("PullUp");
	public static int GrabStair = Animator.StringToHash ("isGrabStair");
	public static int Landing = Animator.StringToHash ("Landing");
	public static int MeleeAttack = Animator.StringToHash ("MeleeAttack");
	public static int RangedAttack = Animator.StringToHash ("RangedAttack");
}