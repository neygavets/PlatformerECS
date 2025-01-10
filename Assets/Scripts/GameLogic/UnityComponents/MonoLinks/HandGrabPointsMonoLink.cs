using UnityEngine;
using Leopotam.Ecs;
using GameLogic.Components.Characters;

namespace GameLogic.UnityComponents
{
	public class HandGrabPointsMonoLink : MonoLink<HandGrabPointsLink>
	{
		[SerializeField]
		private Transform _rightHand;

		[SerializeField]
		private Transform _leftHand;

		public override void Make ( ref EcsEntity entity )
		{
			entity.Get<HandGrabPointsLink> () = new HandGrabPointsLink
			{
				Right = _rightHand,
				Left = _leftHand
			};
		}
	}
}