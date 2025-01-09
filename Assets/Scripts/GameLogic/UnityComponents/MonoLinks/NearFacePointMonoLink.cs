using Common;
using Leopotam.Ecs;
using Movements;
using UnityEngine;

namespace GameLogic.UnityComponents
{
	public class NearFacePointMonoLink : MonoLink<NearFacePointLink>
	{
		[SerializeField]
		private Transform _pointTransform;

		public override void Make ( ref EcsEntity entity )
		{
			entity.Get<NearFacePointLink> () = new NearFacePointLink
			{
				Point = _pointTransform
			};
		}
	}
}