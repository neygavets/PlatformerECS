using Combat;
using Common;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.UnityComponents
{
	public class GunpointMonoLink : MonoLink<GunpointLink>
	{
		[SerializeField]
		private Transform _gunpoint;

		public override void Make ( ref EcsEntity entity )
		{
			entity.Get<GunpointLink> () = new GunpointLink
			{
				Value = _gunpoint
			};
		}
	}
}