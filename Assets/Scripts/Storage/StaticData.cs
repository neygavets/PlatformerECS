using UnityEngine;

[CreateAssetMenu (menuName = "Config/StaticData", fileName = "StaticData", order = 0)]
public class StaticData : ScriptableObject {
	[SerializeField] GameObject playerPrefab;
	[SerializeField] GameObject inputPrefab;

	public GameObject PlayerPrefab { get => playerPrefab; }
	public GameObject InputPrefab { get => inputPrefab; }
}