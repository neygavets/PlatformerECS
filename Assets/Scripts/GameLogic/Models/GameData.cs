using GameLogic.Models.Characters;
using UnityEngine;

namespace GameLogic.Models
{
	[CreateAssetMenu (menuName = "Config/StaticData", fileName = "StaticData", order = 0)]
	public class GameData : ScriptableObject
	{
		[SerializeField]
		private PlayerData _player;

		[SerializeField]
		private GameObject _inputPrefab;

		public PlayerData Player { get => _player; }
		public GameObject InputPrefab { get => _inputPrefab; }
	}
}