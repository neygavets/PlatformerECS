using UnityEngine;

namespace GameLogic.Components.Spawners
{
	public struct SpawnPrefab
	{
		public GameObject Prefab;
		public Vector3 Position;
		public Quaternion Rotation;
		public Transform Parent;
	}
}