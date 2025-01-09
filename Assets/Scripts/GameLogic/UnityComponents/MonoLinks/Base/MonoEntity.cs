using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic.UnityComponents
{
	public class MonoEntity : MonoBehaviour
	{
		public EcsEntity Entity { get => _entity; }

		private EcsEntity _entity;
		private MonoLinkBase[] _monoLinks;

		public void Link ( ref EcsEntity entity )
		{
			_entity = entity;
			_monoLinks = GetComponents<MonoLinkBase> ();
			foreach (MonoLinkBase monoLink in _monoLinks)
			{
				monoLink.Make (ref entity);
			}
		}
	}
}