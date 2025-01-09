using UnityEngine;
namespace Combat {
	public enum WeaponTypesByRange { Melee, Range }
	public enum WeaponTypesByGrab { One, Two, Paired }

	[CreateAssetMenu (menuName = "Gameplay/Weapon")]
	public class WeaponData : ScriptableObject {
		[SerializeField] GameObject prefab;
		[SerializeField] float cooldown;
		[SerializeField] int minDamage;
		[SerializeField] int maxDamage;
		[SerializeField] WeaponTypesByRange weaponTypeByRange;
		[SerializeField] WeaponTypesByGrab weaponTypeByGrab;

		public GameObject Prefab { get => prefab; set => prefab = value; }
		public float Cooldown { get => cooldown; set => cooldown = value; }
		public int MinDamage { get => minDamage; set => minDamage = value; }
		public int MaxDamage { get => maxDamage; set => maxDamage = value; }
		public WeaponTypesByRange WeaponTypeByRange { get => weaponTypeByRange; set => weaponTypeByRange = value; }
		public WeaponTypesByGrab WeaponTypeByGrab { get => weaponTypeByGrab; set => weaponTypeByGrab = value; }
	}
}