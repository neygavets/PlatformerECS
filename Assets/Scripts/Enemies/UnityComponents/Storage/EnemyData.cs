using UnityEngine;

namespace Enemies {
	[CreateAssetMenu (menuName = "Gameplay/Enemy")]
	public class EnemyData : ScriptableObject {
		[SerializeField] GameObject prefab;
		[SerializeField] [Range (1, 9999)] int health;
		[SerializeField] bool isBoss;

		public GameObject Prefab { get => prefab; set => prefab = value; }
		public int Health { get => health; set => health = value; }
		public bool IsBoss { get => isBoss; set => isBoss = value; }
	}
}
