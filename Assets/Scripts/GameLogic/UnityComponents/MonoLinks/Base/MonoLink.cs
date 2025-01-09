using Leopotam.Ecs;

namespace GameLogic.UnityComponents
{
	public class MonoLink<T> : MonoLinkBase where T : struct
	{
		public T Value;

		public override void Make ( ref EcsEntity entity )
		{
			if (entity.Has<T> ())
			{
				return;
			}
			entity.Get<T> () = Value;
		}
	}
}