using UnityEngine;

namespace GameLogic.Models.Traps
{
	[CreateAssetMenu (menuName = "Gameplay/DamageZone")]
	public class TrapData : ScriptableObject
	{
		[SerializeField]
		private GameObject _prefab;

		[SerializeField]
		private float _cooldown;

		[SerializeField]
		private int _damage;

		[SerializeField]
		private bool _isSingleUse;

		public GameObject Prefab { get => _prefab; set => _prefab = value; }
		public float Cooldown { get => _cooldown; set => _cooldown = value; }
		public int Damage { get => _damage; set => _damage = value; }
		public bool IsSingleUse { get => _isSingleUse; set => _isSingleUse = value; }
	}
}