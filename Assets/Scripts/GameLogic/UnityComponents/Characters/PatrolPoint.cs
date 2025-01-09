using UnityEditor;
using UnityEngine;

namespace GameLogic.UnityComponents
{
	public class PatrolPoint : EnemyPoint
	{
		[SerializeField]
		private Transform _endPoint;

#if UNITY_EDITOR
		protected override void Visualization ()
		{
			base.Visualization ();
			Handles.DrawSolidDisc (_endPoint.position, Vector3.forward, 0.5f);
			Handles.Label (_endPoint.position, "end point of patrol");
		}
#endif
	}
}
