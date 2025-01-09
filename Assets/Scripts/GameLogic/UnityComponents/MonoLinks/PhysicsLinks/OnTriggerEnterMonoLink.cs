using Leopotam.Ecs;
using UnityEngine;
using Common;

namespace GameLogic.UnityComponents
{
	[RequireComponent (typeof (Collider2D))]
	public class OnTriggerEnterMonoLink : PhysicsLinkBase
	{
		void OnTriggerEnter2D ( Collider2D other )
		{
			Entity.Get<OnTriggerEnterEvent> () = new OnTriggerEnterEvent ()
			{
				Value = other,
			};
		}
	}
}