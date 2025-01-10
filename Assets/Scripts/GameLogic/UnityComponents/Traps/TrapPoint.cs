using GameLogic.Models.Traps;
using UnityEditor;
using UnityEngine;

namespace GameLogic.UnityComponents
{
	/// <summary>
	/// Точка спавна ловушки
	/// </summary>
	public class TrapPoint : MonoBehaviour
	{
		[SerializeField]
		private TrapData _data;

		public TrapData Data { get => _data; set => _data = value; }

#if UNITY_EDITOR
		private void OnDrawGizmos ()
		{
			Handles.color = new Color (1.0f, 0.5f, 0, 0.2f);
			Handles.DrawSolidDisc (transform.position, Vector3.forward, 0.5f);
			Handles.Label (transform.position, _data.name);
		}
#endif
	}
}
