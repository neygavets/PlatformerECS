using UnityEngine;

namespace Movements {
	[CreateAssetMenu (menuName = "Gameplay/MotionConfig")]
	public class MotionConfig : ScriptableObject {
		[SerializeField] float moveAcceleration = 40.0f;
		[SerializeField] float dashAcceleration = 5.0f;
		[SerializeField] float maxMoveSpeed = 6.0f;
		[SerializeField] float maxDashSpeed = 10.0f;
		[SerializeField] float jumpForce = 1100.0f;
		[SerializeField] float jumpGravityScale = 3.0f;
		[SerializeField] float fallGravityScale = 5.0f;
		[SerializeField] float groundedGravityScale = 1.0f;

		/// <summary>
		/// Величина ускорения для обычного перемещения
		/// </summary>
		public float MoveAcceleration { get => moveAcceleration; }
		/// <summary>
		/// Величина ускорения для рывка
		/// </summary>
		public float DashAcceleration { get => dashAcceleration; }
		/// <summary>
		/// Максимальная скорость ходьбы
		/// </summary>
		public float MaxMoveSpeed { get => maxMoveSpeed; }
		/// <summary>
		/// максимальная скорость рывка
		/// </summary>
		public float MaxDashSpeed { get => maxDashSpeed; }
		/// <summary>
		/// Сила прыжка
		/// </summary>
		public float JumpForce { get => jumpForce; }
		/// <summary>
		/// Модификатор гравитации для прыжка
		/// </summary>
		public float JumpGravityScale { get => jumpGravityScale; }
		/// <summary>
		/// Модификатор гравитации для падения
		/// </summary>
		public float FallGravityScale { get => fallGravityScale; }
		/// <summary>
		/// Модификатор гравитации тела, стоящего на поверхности
		/// </summary>
		public float GroundedGravityScale { get => groundedGravityScale; }
	}
}