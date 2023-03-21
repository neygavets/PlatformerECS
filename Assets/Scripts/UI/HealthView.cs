using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour {
	[SerializeField] Text hpText;

	public void Set (int currentHP, int maxHP) {
		hpText.text = (currentHP<0 ? 0 : currentHP) + "/" + maxHP;
	}
}