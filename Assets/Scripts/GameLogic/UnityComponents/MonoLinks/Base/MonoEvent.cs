using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.UnityComponents
{
	public abstract class MonoEvent : MonoBehaviour
	{
		protected EcsEntity Entity;

		public void Link ( ref EcsEntity entity )
		{
			Entity = entity;
		}
	}
}
