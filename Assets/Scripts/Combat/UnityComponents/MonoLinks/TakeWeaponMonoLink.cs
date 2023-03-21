using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace Combat {
    public class TakeWeaponMonoLink : MonoLink<TakeWeapon> {
		[SerializeField] WeaponData data;
		[SerializeField] Transform linkPoint;

		public override void Make ( ref EcsEntity entity ) {
			entity.Get<TakeWeapon> () = new TakeWeapon {
				Data = data,
				LinkPoint = linkPoint
			};
		}
	}
}