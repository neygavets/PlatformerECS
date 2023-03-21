using Leopotam.Ecs;
using UnityEngine;

namespace Common {
	[RequireComponent (typeof (Collider2D))]
	public class OnTriggerEnterMonoLink : PhysicsLinkBase {
		void OnTriggerEnter2D ( Collider2D other ) {
			entity.Get<OnTriggerEnterEvent> () = new OnTriggerEnterEvent () {
				Value = other,
			};
		}
	}
}