using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common {

	public class ObjectPool : MonoBehaviour {

		[SerializeField] GameObject objectToPool = null;
		[SerializeField] int amountToPool = 10;
		private List<GameObject> pooledObjects;
		private LayerMask mask;

		public void Init ( LayerMask mask ) {
			this.mask = mask;
			if (objectToPool != null) {
				pooledObjects = new List<GameObject> ();
				for (int i = 0; i < amountToPool; i++) {
					AddNewObject (transform);
				}
			} else {
				Debug.Log ("Objects are not assigned to the pool.");
			}
		}

		public void ReturnObject ( GameObject obj ) {
			obj.transform.SetParent (transform);
			obj.SetActive (false);
		}

		public GameObject GetPooledObject () {
			// Ищем первый обьект в пуле, который не задействован в сцене
			for (int i = 0; i < amountToPool; i++) {
				if (!pooledObjects[i].activeInHierarchy) {
					pooledObjects[i].transform.parent = null;
					return pooledObjects[i];
				}
			}
			// Если все обьекты в пуле уже задействованы, расширяем пул
			return AddNewObject(null);
		}

		private GameObject AddNewObject (Transform parent) {
			GameObject tmp = Instantiate (objectToPool, parent);
			tmp.SetActive (false);
			tmp.layer = mask;
			pooledObjects.Add (tmp);
			return tmp;
		}
	}
}