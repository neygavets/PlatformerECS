using Combat;
using UnityEngine;

namespace Characters {
	public class CharacterData : ScriptableObject {
		[SerializeField] GameObject prefab;
		[SerializeField] WeaponData weapon;
		[SerializeField] [Min (1)] [Tooltip ("������ �� ���������� ��������")] int stamina;
		[SerializeField] [Min (0)] [Tooltip ("������ �� ���� ����� �������� ���")] int strength;
		[SerializeField] [Min (0)] [Tooltip ("������ �� ���� ����� �������� ���")] int agility;
		[SerializeField] [Min (0)] [Tooltip ("������ �� ���� ����������")] int intellect;

		public GameObject Prefab { get => prefab; set => prefab = value; }
		public WeaponData Weapon { get => weapon; set => weapon = value; }
		public int Stamina { get => stamina; set => stamina = value; }
		public int Strength { get => strength; set => strength = value; }
		public int Agility { get => agility; set => agility = value; }
		public int Intellect { get => intellect; set => intellect = value; }
	}
}