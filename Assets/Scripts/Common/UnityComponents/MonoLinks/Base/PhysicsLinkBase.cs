using Leopotam.Ecs;

namespace Common {
	public abstract class PhysicsLinkBase : MonoLinkBase {
		protected EcsEntity entity;
		public override void Make ( ref EcsEntity entity ) {
			this.entity = entity;
		}
	}
}