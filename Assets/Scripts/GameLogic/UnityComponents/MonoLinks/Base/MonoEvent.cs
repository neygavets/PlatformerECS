using Leopotam.Ecs;
using UnityEngine;

namespace Common {
	public abstract class MonoEvent : MonoBehaviour {
		protected EcsEntity entity;
		public void Link ( ref EcsEntity entity ) {
			this.entity = entity;
		}
	}
}
