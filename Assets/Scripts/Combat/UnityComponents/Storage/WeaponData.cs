using UnityEngine;
namespace Combat {
	public enum WeaponTypes { Melee, Range }

	[CreateAssetMenu (menuName = "Gameplay/Weapon")]
	public class WeaponData : ScriptableObject {
		[SerializeField] GameObject prefab;
		[SerializeField] float cooldown;
		[SerializeField] int minDamage;
		[SerializeField] int maxDamage;
		[SerializeField] WeaponTypes weaponType;

		public GameObject Prefab { get => prefab; set => prefab = value; }
		public float Cooldown { get => cooldown; set => cooldown = value; }
		public int MinDamage { get => minDamage; set => minDamage = value; }
		public int MaxDamage { get => maxDamage; set => maxDamage = value; }
		public WeaponTypes WeaponType { get => weaponType; set => weaponType = value; }
	}
}