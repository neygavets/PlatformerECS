using GameLogic.Models.Characters;
using Leopotam.Ecs;
using GameLogic.Components.Movements;
using UnityEngine;

namespace GameLogic.UnityComponents
{
	public class MotionConfigMonoLink : MonoLink<MotionConfigLink>
	{
		[SerializeField]
		private MotionConfig _config;

		public override void Make ( ref EcsEntity entity )
		{
			entity.Get<MotionConfigLink> () = new MotionConfigLink
			{
				Value = _config
			};
		}
	}
}