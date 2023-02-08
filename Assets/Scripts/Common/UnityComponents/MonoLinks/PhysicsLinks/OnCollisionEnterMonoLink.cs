using Leopotam.Ecs;
using UnityEngine;

namespace Common {
	[RequireComponent (typeof (Collider))]
	public class OnCollisionEnterMonoLink : PhysicsLinkBase {
		public void OnCollisionEnter ( Collision other ) {
			entity.Get<OnCollisionEnterEvent> () = new OnCollisionEnterEvent {
				Collision = other,
				Sender = gameObject
			};
		}
	}
}