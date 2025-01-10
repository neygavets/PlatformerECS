using GameLogic.Components.Common;
using Leopotam.Ecs;
using Utils;
using GameLogic.Components.Movements;

namespace GameLogic.Systems.Movements
{
	sealed class CheckGroundSystem : IEcsRunSystem
	{
		// auto-injected fields.
		private EcsFilter<FreeMovingFlag, Rigidbody2DLink, PhysicalBodySizeLink, MotionConfigLink> _checkedFilter = null;

		void IEcsRunSystem.Run ()
		{
			foreach (int i in _checkedFilter)
			{
				ref EcsEntity entity = ref _checkedFilter.GetEntity (i);
				bool isGrounded = ObstacleChecker.CheckUnderfoot (_checkedFilter.Get2 (i).Value.transform.position, _checkedFilter.Get3 (i).Size.x, LayerMasks.Ground);

				if (isGrounded)
				{
					entity.Del<FallingFlag> ();
					if (!entity.Has<GroundedFlag> ())
					{
						_checkedFilter.Get2 (i).Value.gravityScale = _checkedFilter.Get4 (i).Value.GroundedGravityScale;
						entity.Get<GroundedFlag> ();
						entity.Get<LandingAnimationFlag> ();
					}
				}
				else
				{
					entity.Del<GroundedFlag> ();
				}
			}
		}
	}
}