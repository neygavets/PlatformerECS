using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Combat {
    public class ProjectilePoolMonoLink : MonoLink<ProjectilePoolLink> {
		[SerializeField] ObjectPool objectPool;

		public override void Make ( ref EcsEntity entity ) {
			objectPool.Init (LayerMasks.GetOwnerMask(entity.Get<Owner>().Value));
			entity.Get<ProjectilePoolLink> () = new ProjectilePoolLink {
				Value = objectPool
			};
		}
	}
}
