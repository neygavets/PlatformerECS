using GameLogic.Components.Combat;
using Leopotam.Ecs;
using UnityEngine;

namespace UI
{
	/// <summary>
	/// Отображение параметров персонажа
	/// </summary>
	public class CharacterInfoView : MonoBehaviour
	{
		[SerializeField]
		private HealthView _healthView;

		public virtual void UpdateHealth ( Health health ) => _healthView.Set (health.Current, health.Max);

		public virtual void LinkEntity ( EcsEntity entity )
		{
			UpdateHealth (entity.Get<Health> ());
			gameObject.SetActive (true);
		}
	}
}