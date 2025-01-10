using GameLogic.Models.Characters;
using UnityEditor;
using UnityEngine;

namespace GameLogic.UnityComponents
{
	public class EnemyPoint : MonoBehaviour
	{
		[SerializeField] 
		protected EnemyData EnemyData;

		public EnemyData Data { get => EnemyData; set => EnemyData = value; }

#if UNITY_EDITOR
		protected virtual void Visualization ()
		{
			Handles.color = new Color (1.0f, 0, 0, 0.2f);
			Handles.DrawSolidDisc (transform.position, Vector3.forward, 0.5f);
			Handles.Label (transform.position, EnemyData.name);
		}

		protected void OnDrawGizmos ()
		{
			Visualization ();
		}
#endif
	}
}