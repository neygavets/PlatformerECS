using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Movements {
	public class MotionConfigMonoLink : MonoLink<MotionConfigLink> {
		[SerializeField]
		MotionConfig config;

		public override void Make ( ref EcsEntity entity ) {
			entity.Get<MotionConfigLink> () = new MotionConfigLink {
				Value = config
			};
		}
	}
}