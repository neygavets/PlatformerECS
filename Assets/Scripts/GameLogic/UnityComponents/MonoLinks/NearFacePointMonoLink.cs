using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Movements {
	public class NearFacePointMonoLink : MonoLink<NearFacePointLink> {
		[SerializeField] Transform pointTransform;

		public override void Make ( ref EcsEntity entity ) {
			entity.Get<NearFacePointLink> () = new NearFacePointLink {
				Point = pointTransform
			};
		}
	}
}