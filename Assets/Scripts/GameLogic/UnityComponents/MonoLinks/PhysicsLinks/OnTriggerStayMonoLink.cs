using Leopotam.Ecs;
using UnityEngine;
using Common;

namespace GameLogic.UnityComponents
{
	[RequireComponent (typeof (Collider2D))]
	public class OnTriggerStayMonoLink : PhysicsLinkBase
	{
		void OnTriggerStay2D ( Collider2D other )
		{
			Entity.Get<OnTriggerStayEvent> () = new OnTriggerStayEvent ()
			{
				Value = other,
			};
		}
	}
}