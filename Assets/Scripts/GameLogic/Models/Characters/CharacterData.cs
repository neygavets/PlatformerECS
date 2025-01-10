using GameLogic.Models.Weapons;
using UnityEngine;

namespace GameLogic.Models.Characters
{
	public class CharacterData : ScriptableObject
	{
		[SerializeField]
		private GameObject _prefab;

		[SerializeField]
		private WeaponData _weapon;

		[SerializeField][Min (1)][Tooltip ("Влияет на количество здоровья")]
		private int _stamina;

		[SerializeField][Min (0)][Tooltip ("Влияет на силу атаки ближнего боя")]
		private int _strength;

		[SerializeField][Min (0)][Tooltip ("Влияет на силу атаки дальнего боя")]
		private int _agility;

		[SerializeField][Min (0)][Tooltip ("Влияет на силу заклинаний")]
		private int _intellect;

		[SerializeField][Min (0)][Tooltip ("Влияет на защиту от физического урона")]
		private int _armor;

		public GameObject Prefab { get => _prefab; set => _prefab = value; }
		public WeaponData Weapon { get => _weapon; set => _weapon = value; }
		public int Stamina { get => _stamina; set => _stamina = value; }
		public int Strength { get => _strength; set => _strength = value; }
		public int Agility { get => _agility; set => _agility = value; }
		public int Intellect { get => _intellect; set => _intellect = value; }
		public int Armor { get => _armor; set => _armor = value; }
	}
}