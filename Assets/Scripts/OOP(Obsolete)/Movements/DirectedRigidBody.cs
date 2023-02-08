using UnityEngine;

namespace OOP {
	public class DirectedRigidBody : IDirected {
		private readonly Vector3 flippedScale = new Vector3 (-1, 1, 1);
		private float minFlipSpeed = 0.1f; // ����������� �������� ��������, ��� ������� ���� ����������� � ����������� ����� ��������
		private bool isFlipped;
		private Rigidbody2D rigidbody;
		private Transform transform;

		public DirectedRigidBody ( Rigidbody2D rigidbody, Transform transform ) {
			this.rigidbody = rigidbody;
			this.transform = transform;
		}

		public bool CompareDirections ( float directionX ) {
			// ���������, �������� �� ������ � ������ �������
			return directionX == transform.localScale.x;
		}

		public void ReverseDirection () {
			if (isFlipped) {
				isFlipped = false;
				transform.localScale = Vector3.one;
			} else {
				isFlipped = true;
				transform.localScale = flippedScale;
			}
		}

		public void UpdateDirection () {
			// �������������� ������ � ����������� ��������
			if (rigidbody.velocity.x > minFlipSpeed && isFlipped) {
				isFlipped = false;
				transform.localScale = Vector3.one;
			} else if (rigidbody.velocity.x < -minFlipSpeed && !isFlipped) {
				isFlipped = true;
				transform.localScale = flippedScale;
			}
		}
	}
}
