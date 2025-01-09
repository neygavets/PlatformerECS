using Combat;
using UnityEngine;

namespace Characters {
	public class CharacterData : ScriptableObject {
		[SerializeField] GameObject prefab;
		[SerializeField] WeaponData weapon;
		[SerializeField] [Min (1)] [Tooltip ("Влияет на количество здоровья")] int stamina;
		[SerializeField] [Min (0)] [Tooltip ("Влияет на силу атаки ближнего боя")] int strength;
		[SerializeField] [Min (0)] [Tooltip ("Влияет на силу атаки дальнего боя")] int agility;
		[SerializeField] [Min (0)] [Tooltip ("Влияет на силу заклинаний")] int intellect;

		public GameObject Prefab { get => prefab; set => prefab = value; }
		public WeaponData Weapon { get => weapon; set => weapon = value; }
		public int Stamina { get => stamina; set => stamina = value; }
		public int Strength { get => strength; set => strength = value; }
		public int Agility { get => agility; set => agility = value; }
		public int Intellect { get => intellect; set => intellect = value; }
	}
}