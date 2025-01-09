using UnityEngine;

namespace GameLogic.UnityComponents
{
	public class GrabOffset : MonoBehaviour
	{
		[SerializeField]
		private Transform _linkPoint;

		void Start ()
		{
			transform.localPosition = Vector3.zero - _linkPoint.localPosition;
			transform.localRotation = Quaternion.identity;
		}
	}
}