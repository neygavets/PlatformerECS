using UnityEngine;
namespace Traps {

	[CreateAssetMenu (menuName = "Gameplay/DamageZone")]
	public class DamageZoneData : ScriptableObject {
		[SerializeField] GameObject prefab;
		[SerializeField] float cooldown;
		[SerializeField] int damage;
		[SerializeField] bool isSingleUse;

		public GameObject Prefab { get => prefab; set => prefab = value; }
		public float Cooldown { get => cooldown; set => cooldown = value; }
		public int Damage { get => damage; set => damage = value; }
		public bool IsSingleUse { get => isSingleUse; set => isSingleUse = value; }
	}
}