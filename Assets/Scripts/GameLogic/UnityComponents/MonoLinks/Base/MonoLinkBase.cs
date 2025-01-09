using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.UnityComponents
{
	[RequireComponent (typeof (MonoEntity))]
	public abstract class MonoLinkBase : MonoBehaviour
	{
		public abstract void Make ( ref EcsEntity entity );
	}
}