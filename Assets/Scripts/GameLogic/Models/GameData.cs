using Characters;
using UnityEngine;

[CreateAssetMenu (menuName = "Config/StaticData", fileName = "StaticData", order = 0)]
public class GameData : ScriptableObject {
	[SerializeField] PlayerData player;
	[SerializeField] GameObject inputPrefab;

	public PlayerData Player { get => player; }
	public GameObject InputPrefab { get => inputPrefab; }
}