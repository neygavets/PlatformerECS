using Utils;
using UnityEngine;

namespace OOP {
	public class HeroMovement : MonoBehaviour {
		public Movements.MotionConfig settings;
		public BaseAnimations animations;

		// ������������ ����� ��� �������� ����������
		public GameObject pointOverhead;
		public GameObject pointGrab;
		public GameObject pointClimbLedge;

		public bool IsGrounded { get; set; } // ��������� �� �����������
		public bool Busy { get; set; } // ������� �����, ��� �� ������ ��� �� ��� � ���� ���������
		public IDirected direction;
		[HideInInspector] public HeroInputControl inputControl;
		protected StateMachine movableSM;
		public State standingState, jumpState, fallState, stealthState, duckState, grabHoldState, pullUpState, grabStairState, dashState;

		[HideInInspector] public float moveInput;
		[HideInInspector] public Rigidbody2D movableRigidbody;
		[HideInInspector] public LayerMask groundedMask, wallMask, stairMask;
		[HideInInspector] public CapsuleCollider2D bodyCollider;
		[HideInInspector] public Vector2 normalBodySize;
		[HideInInspector] public Vector2 normalBodyOffset;


		void Start () {
			// ������� ����������
			groundedMask = LayerMask.GetMask ("Ground", "Wall");
			wallMask = LayerMask.GetMask ("Wall");
			stairMask = LayerMask.GetMask ("Stair");
			bodyCollider = GetComponent<CapsuleCollider2D> ();
			normalBodySize = bodyCollider.size;
			normalBodyOffset = bodyCollider.offset;
			movableRigidbody = GetComponent<Rigidbody2D> ();
			inputControl = GetComponent<HeroInputControl> ();

			direction = new DirectedRigidBody (movableRigidbody, transform);

			movableSM = new StateMachine ();
			// �������������� ��������� � ����������� ���������
			standingState = new StandingState (movableSM, this);
			jumpState = new JumpState (movableSM, this);
			fallState = new FallState (movableSM, this);
			stealthState = new StealthState (movableSM, this);
			duckState = new DuckState (movableSM, this);
			grabHoldState = new GrabHoldState (movableSM, this);
			pullUpState = new PullUpState (movableSM, this);
			grabStairState = new GrabStairState (movableSM, this);
			dashState = new DashState (movableSM, this);
			movableSM.Initialize (standingState);

			inputControl.MovePerformed += Move;
			inputControl.MoveCanceled += Move;
		}

		private void OnDestroy () {
			inputControl.MovePerformed -= Move;
			inputControl.MoveCanceled -= Move;
		}

		void Update () {
			movableSM.CurrentState?.LogicUpdate ();
		}

		void FixedUpdate () {
			IsGrounded = ObstacleChecker.CheckUnderfoot (transform.position, bodyCollider.size.x, groundedMask); // ���������, �������� �� ����� ��� ���������
			movableSM.CurrentState?.PhysicsUpdate ();
		}

		public void UpdateGravityScale () {
			if (IsGrounded) {
				movableRigidbody.gravityScale = settings.GroundedGravityScale;
			} else {
				// ���� ���� �� �� �����, ���������� ����������� ���� ������� ��� �������� ����� ��� ��� �������
				movableRigidbody.gravityScale = movableRigidbody.velocity.y > 0.0f ? settings.JumpGravityScale : settings.FallGravityScale;
			}
		}

		void Move ( float value ) {
			moveInput = value;
		}

		private void OnDrawGizmos () {
			Gizmos.color = Color.red;
			//Gizmos.DrawSphere (new Vector3(transform.position.x, transform.position.y + 1.75f), 0.18f);
			Gizmos.DrawLine (pointOverhead.transform.position, pointOverhead.transform.position + new Vector3 (0.2f, 0, 0));
			Gizmos.DrawLine (pointGrab.transform.position, pointGrab.transform.position + new Vector3 (0.2f, 0, 0));
			//		Gizmos.DrawSphere (pointUp.transform.position, 0.05f);
			//		Gizmos.DrawSphere (pointDown.transform.position, 0.05f);
		}
	}
}