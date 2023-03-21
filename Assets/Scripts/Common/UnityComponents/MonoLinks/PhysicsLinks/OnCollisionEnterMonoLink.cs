using Leopotam.Ecs;
using UnityEngine;

namespace Common {
	[RequireComponent (typeof (Collider2D))]
	public class OnCollisionEnterMonoLink : PhysicsLinkBase {
		void OnCollisionEnter2D ( Collision2D other ) {
			entity.Get<OnCollisionEnterEvent> () = new OnCollisionEnterEvent {
				Value = other,
			};
		}
	}
}