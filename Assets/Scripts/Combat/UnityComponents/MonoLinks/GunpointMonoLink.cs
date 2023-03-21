using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Combat {
	public class GunpointMonoLink : MonoLink<GunpointLink> {
		[SerializeField] Transform gunpoint;

		public override void Make ( ref EcsEntity entity ) {
			entity.Get<GunpointLink> () = new GunpointLink {
				Value = gunpoint
			};
		}
	}
}