using GameLogic.Components.Common;
using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace GameLogic.UnityComponents
{
	[RequireComponent (typeof (Collider2D))]
	public class Collider2DSizeMonoLink : MonoLink<PhysicalBodySizeLink>
	{
		public override void Make ( ref EcsEntity entity )
		{
			entity.Get<PhysicalBodySizeLink> () = new PhysicalBodySizeLink ()
			{
				Size = Collider2DUtils.GetSize (GetComponent<Collider2D> ()),
				Offset = GetComponent<Collider2D> ().offset
			};
		}
	}
}