using Leopotam.Ecs;
using UnityEngine;
using Common;

namespace GameLogic.UnityComponents
{
	[RequireComponent (typeof (Collider2D))]
	public class OnCollisionEnterMonoLink : PhysicsLinkBase
	{
		void OnCollisionEnter2D ( Collision2D other )
		{
			Entity.Get<OnCollisionEnterEvent> () = new OnCollisionEnterEvent
			{
				Value = other,
			};
		}
	}
}