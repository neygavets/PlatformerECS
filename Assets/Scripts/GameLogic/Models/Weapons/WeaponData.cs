using UnityEngine;

namespace GameLogic.Models.Weapons
{
	public enum WeaponTypesByRange
	{
		Melee,
		Range
	}

	public enum WeaponTypesByGrab
	{
		One,
		Two,
		Paired
	}

	[CreateAssetMenu (menuName = "Gameplay/Weapon")]
	public class WeaponData : ScriptableObject
	{
		[SerializeField]
		private GameObject _prefab;

		[SerializeField]
		private float _cooldown;

		[SerializeField]
		private int _minDamage;

		[SerializeField]
		private int _maxDamage;

		[SerializeField]
		private WeaponTypesByRange _weaponTypeByRange;

		[SerializeField]
		private WeaponTypesByGrab _weaponTypeByGrab;

		public GameObject Prefab { get => _prefab; set => _prefab = value; }
		public float Cooldown { get => _cooldown; set => _cooldown = value; }
		public int MinDamage { get => _minDamage; set => _minDamage = value; }
		public int MaxDamage { get => _maxDamage; set => _maxDamage = value; }
		public WeaponTypesByRange WeaponTypeByRange { get => _weaponTypeByRange; set => _weaponTypeByRange = value; }
		public WeaponTypesByGrab WeaponTypeByGrab { get => _weaponTypeByGrab; set => _weaponTypeByGrab = value; }
	}
}