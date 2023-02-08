using Leopotam.Ecs;
using UnityEngine;

namespace Common {
	[RequireComponent (typeof (Collider))]
	public class OnTriggerEnterMonoLink : PhysicsLinkBase {
		private void OnTriggerEnter ( Collider other ) {
			entity.Get<OnTriggerEnterEvent> () = new OnTriggerEnterEvent () {
				Collider = other,
				Sender = gameObject
			};
		}
	}
}