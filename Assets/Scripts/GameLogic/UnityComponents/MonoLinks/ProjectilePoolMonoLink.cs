using Combat;
using Common;
using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace GameLogic.UnityComponents
{
	public class ProjectilePoolMonoLink : MonoLink<ProjectilePoolLink>
	{
		[SerializeField]
		private ObjectPool _objectPool;

		public override void Make ( ref EcsEntity entity )
		{
			_objectPool.Init (LayerMasks.GetOwnerMask (entity.Get<Owner> ().Value));
			entity.Get<ProjectilePoolLink> () = new ProjectilePoolLink
			{
				Value = _objectPool
			};
		}
	}
}
