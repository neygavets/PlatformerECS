using Leopotam.Ecs;
using UnityEngine;
using GameLogic.Components.Common;

namespace GameLogic.UnityComponents
{
	[RequireComponent (typeof (Collider2D))]
	public class OnTriggerExitMonoLink : PhysicsLinkBase
	{
		void OnTriggerExit2D ( Collider2D other )
		{
			Entity.Get<OnTriggerExitEvent> () = new OnTriggerExitEvent ()
			{
				Value = other,
			};
		}
	}
}