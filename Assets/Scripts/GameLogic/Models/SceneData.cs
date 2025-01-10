using Cinemachine;
using UnityEngine;
using UI;
using GameLogic.UnityComponents;

namespace GameLogic.Models
{
	public class SceneData : MonoBehaviour
	{
		public CinemachineBrain cinemachineBrain;
		public PrefabFactory factory;
		public CharacterInfoView playerInfo;
		public CharacterInfoView enemyInfo;
		public Transform spawnPlayerPosition;
		public EnemyPoint[] spawnEnemyPoints;
		public TrapPoint[] spawnTrapPoints;
	}
}