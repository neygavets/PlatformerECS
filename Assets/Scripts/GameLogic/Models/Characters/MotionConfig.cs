using UnityEngine;

namespace GameLogic.Models.Characters
{
	[CreateAssetMenu (menuName = "Gameplay/MotionConfig")]
	public class MotionConfig : ScriptableObject
	{
		[SerializeField]
		private float _moveAcceleration = 40.0f;

		[SerializeField]
		private float _dashAcceleration = 5.0f;

		[SerializeField]
		private float _maxMoveSpeed = 6.0f;

		[SerializeField]
		private float _maxDashSpeed = 10.0f;

		[SerializeField]
		private float _jumpForce = 1100.0f;

		[SerializeField]
		private float _jumpGravityScale = 3.0f;

		[SerializeField]
		private float _fallGravityScale = 5.0f;

		[SerializeField]
		private float _groundedGravityScale = 1.0f;

		/// <summary>
		/// Величина ускорения для обычного перемещения
		/// </summary>
		public float MoveAcceleration { get => _moveAcceleration; }

		/// <summary>
		/// Величина ускорения для рывка
		/// </summary>
		public float DashAcceleration { get => _dashAcceleration; }

		/// <summary>
		/// Максимальная скорость ходьбы
		/// </summary>
		public float MaxMoveSpeed { get => _maxMoveSpeed; }

		/// <summary>
		/// максимальная скорость рывка
		/// </summary>
		public float MaxDashSpeed { get => _maxDashSpeed; }

		/// <summary>
		/// Сила прыжка
		/// </summary>
		public float JumpForce { get => _jumpForce; }

		/// <summary>
		/// Модификатор гравитации для прыжка
		/// </summary>
		public float JumpGravityScale { get => _jumpGravityScale; }

		/// <summary>
		/// Модификатор гравитации для падения
		/// </summary>
		public float FallGravityScale { get => _fallGravityScale; }

		/// <summary>
		/// Модификатор гравитации тела, стоящего на поверхности
		/// </summary>
		public float GroundedGravityScale { get => _groundedGravityScale; }
	}
}