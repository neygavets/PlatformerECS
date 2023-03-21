using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Movements {
	public class LedgePointsMonoLink : MonoLink<LedgePointsLink> {
		[SerializeField] Transform pointBefore;
		[SerializeField] Transform pointBehind;

		public override void Make ( ref EcsEntity entity ) {
			entity.Get<LedgePointsLink> () = new LedgePointsLink {
				PointBefore = pointBefore,
				PointBehind = pointBehind
			};
		}
	}
}