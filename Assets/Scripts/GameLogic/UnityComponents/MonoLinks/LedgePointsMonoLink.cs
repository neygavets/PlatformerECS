using Common;
using Leopotam.Ecs;
using Movements;
using UnityEngine;

namespace GameLogic.UnityComponents
{
	public class LedgePointsMonoLink : MonoLink<LedgePointsLink>
	{
		[SerializeField]
		private Transform _pointBefore;

		[SerializeField]
		private Transform _pointBehind;

		public override void Make ( ref EcsEntity entity )
		{
			entity.Get<LedgePointsLink> () = new LedgePointsLink
			{
				PointBefore = _pointBefore,
				PointBehind = _pointBehind
			};
		}
	}
}