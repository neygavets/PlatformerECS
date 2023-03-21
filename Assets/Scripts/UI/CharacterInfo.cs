using Combat;
using Leopotam.Ecs;
using UnityEngine;

public class CharacterInfo : MonoBehaviour {
	[SerializeField] HealthView healthView;

	public virtual void UpdateHealth ( Health health ) => healthView.Set (health.Current, health.Max);

	public virtual void LinkEntity ( EcsEntity entity ) {
		UpdateHealth (entity.Get<Health> ());
		gameObject.SetActive (true);
	}
}
