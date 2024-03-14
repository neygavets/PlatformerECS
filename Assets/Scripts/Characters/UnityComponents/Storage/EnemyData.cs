using UnityEngine;

namespace Characters {
	[CreateAssetMenu (menuName = "Gameplay/Enemy")]
	public class EnemyData : CharacterData {
		[SerializeField] [Min (0)] int armor;
		[SerializeField] bool isBoss;

		public bool IsBoss { get => isBoss; set => isBoss = value; }
		public int Armor { get => armor; set => armor = value; }
	}
}
