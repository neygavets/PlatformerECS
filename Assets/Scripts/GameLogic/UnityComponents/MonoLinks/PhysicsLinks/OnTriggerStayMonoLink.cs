using Leopotam.Ecs;
using UnityEngine;

namespace Common {
	[RequireComponent (typeof (Collider2D))]
	public class OnTriggerStayMonoLink : PhysicsLinkBase {
		void OnTriggerStay2D ( Collider2D other ) {
			entity.Get<OnTriggerStayEvent> () = new OnTriggerStayEvent () {
				Value = other,
			};
		}
	}
}