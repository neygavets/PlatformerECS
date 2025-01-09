using Leopotam.Ecs;
using UnityEngine;

namespace Common {
	[RequireComponent (typeof (Collider2D))]
	public class Collider2DMonoLink : MonoLink<Collider2DLink> {
		public override void Make ( ref EcsEntity entity ) {
			entity.Get<Collider2DLink> () = new Collider2DLink {
				Value = GetComponent<Collider2D> ()
			};
		}
	}
}