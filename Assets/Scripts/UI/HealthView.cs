using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	/// <summary>
	/// Отображение здоровья
	/// </summary>
	public class HealthView : MonoBehaviour
	{
		[SerializeField]
		private Text _hpText;

		public void Set ( int currentHP, int maxHP )
		{
			_hpText.text = (currentHP < 0 ? 0 : currentHP) + "/" + maxHP;
		}
	}
}