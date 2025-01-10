using UnityEngine;

namespace GameLogic.Models.Characters
{
	[CreateAssetMenu (menuName = "Gameplay/Enemy")]
	public class EnemyData : CharacterData
	{		
		[SerializeField]
		private bool _isBoss;

		public bool IsBoss { get => _isBoss; set => _isBoss = value; }
	}
}
