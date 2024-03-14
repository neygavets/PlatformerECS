using UnityEngine;
using Leopotam.Ecs;

namespace Common {
    public class HandGrabPointsMonoLink : MonoLink<HandGrabPointsLink> {
        [SerializeField] Transform rightHand;
        [SerializeField] Transform leftHand;

		public override void Make ( ref EcsEntity entity ) {
			entity.Get<HandGrabPointsLink> () = new HandGrabPointsLink {
				Right = rightHand,
				Left = leftHand
			};
		}
	}
}