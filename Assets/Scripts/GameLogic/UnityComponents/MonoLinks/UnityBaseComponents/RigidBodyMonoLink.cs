using GameLogic.Components.Common;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.UnityComponents
{
	[RequireComponent (typeof (Rigidbody2D))]
	public class RigidBodyMonoLink : MonoLink<Rigidbody2DLink>
	{
		public override void Make ( ref EcsEntity entity )
		{
			entity.Get<Rigidbody2DLink> () = new Rigidbody2DLink
			{
				Value = GetComponent<Rigidbody2D> ()
			};
		}
	}
}