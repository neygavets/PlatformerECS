using Leopotam.Ecs;
using UnityEngine;

namespace Common {
	[RequireComponent (typeof (MonoEntity))]
	public abstract class MonoLinkBase : MonoBehaviour {
		public abstract void Make ( ref EcsEntity entity );
	}
}