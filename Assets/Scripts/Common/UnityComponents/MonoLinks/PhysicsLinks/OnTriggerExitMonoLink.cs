using Leopotam.Ecs;
using UnityEngine;

namespace Common {
	[RequireComponent (typeof (Collider2D))]
	public class OnTriggerExitMonoLink : PhysicsLinkBase {
		void OnTriggerExit2D ( Collider2D other ) {
			entity.Get<OnTriggerExitEvent> () = new OnTriggerExitEvent () {
				Value = other,
			};
		}
	}
}