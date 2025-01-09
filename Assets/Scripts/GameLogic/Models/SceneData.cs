using Cinemachine;
using Characters;
using Spawners;
using Traps;
using UnityEngine;

public class SceneData : MonoBehaviour {
	public CinemachineBrain cinemachineBrain;
	public PrefabFactory factory;
	public CharacterInfo playerInfo;
	public CharacterInfo enemyInfo;
	public Transform spawnPlayerPosition;
	public EnemyPoint[] spawnEnemyPoints;
	public TrapPoint[] spawnTrapPoints;
}