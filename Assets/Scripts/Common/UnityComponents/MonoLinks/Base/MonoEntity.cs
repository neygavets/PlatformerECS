using Leopotam.Ecs;
using UnityEngine;

namespace Common {
	public class MonoEntity : MonoBehaviour {
		public EcsEntity Entity { get => entity;}

		private EcsEntity entity;
		private MonoLinkBase[] monoLinks;

		public void Link ( ref EcsEntity entity ) {
			this.entity = entity;
			monoLinks = GetComponents<MonoLinkBase> ();
			foreach (MonoLinkBase monoLink in monoLinks) {
				monoLink.Make (ref entity);
			}
		}
	}
}