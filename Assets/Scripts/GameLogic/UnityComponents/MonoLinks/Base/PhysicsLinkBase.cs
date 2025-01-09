using Leopotam.Ecs;

namespace GameLogic.UnityComponents
{
	public abstract class PhysicsLinkBase : MonoLinkBase
	{
		protected EcsEntity Entity;

		public override void Make ( ref EcsEntity entity )
		{
			Entity = entity;
		}
	}
}