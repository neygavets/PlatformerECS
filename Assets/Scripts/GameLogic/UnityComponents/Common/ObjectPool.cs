using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.UnityComponents
{

	public class ObjectPool : MonoBehaviour
	{
		[SerializeField]
		private GameObject _objectToPool = null;

		[SerializeField]
		private int _amountToPool = 10;

		private List<GameObject> _pooledObjects;
		private LayerMask _mask;

		public void Init ( LayerMask mask )
		{
			_mask = mask;

			if (_objectToPool != null)
			{
				_pooledObjects = new List<GameObject> ();
				for (int i = 0; i < _amountToPool; i++)
				{
					AddNewObject (transform);
				}
			}
			else
			{
				Debug.Log ("Objects are not assigned to the pool.");
			}
		}

		public void ReturnObject ( GameObject obj )
		{
			obj.transform.SetParent (transform);
			obj.SetActive (false);
		}

		public GameObject GetPooledObject ()
		{
			// Ищем первый обьект в пуле, который не задействован в сцене
			for (int i = 0; i < _amountToPool; i++)
			{
				if (!_pooledObjects[i].activeInHierarchy)
				{
					_pooledObjects[i].transform.parent = null;
					return _pooledObjects[i];
				}
			}

			// Если все обьекты в пуле уже задействованы, расширяем пул
			return AddNewObject (null);
		}

		private GameObject AddNewObject ( Transform parent )
		{
			GameObject tmp = Instantiate (_objectToPool, parent);
			tmp.SetActive (false);
			tmp.layer = _mask;
			_pooledObjects.Add (tmp);
			return tmp;
		}
	}
}