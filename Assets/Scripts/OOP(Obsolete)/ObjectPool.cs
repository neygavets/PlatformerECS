using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	[SerializeField] GameObject objectToPool = null;
	[SerializeField] int amountToPool = 10;
	private List<GameObject> pooledObjects;

	void Start () {
		if (objectToPool != null) {
			pooledObjects = new List<GameObject> ();
			GameObject tmp;
			for (int i = 0; i < amountToPool; i++) {
				tmp = Instantiate (objectToPool);
				tmp.SetActive (false);
				pooledObjects.Add (tmp);
			}
		} else {
			Debug.Log ("Objects are not assigned to the pool.");
		}

	}

	public GameObject GetPooledObject () {
		// Ищем первый обьект в пуле, который не задействован в сцене
		for (int i = 0; i < amountToPool; i++) {
			if (!pooledObjects[i].activeInHierarchy) {
				return pooledObjects[i];
			}
		}
		// Если все обьекты в пуле уже задействованы, расширяем пул
		GameObject tmp = Instantiate (objectToPool);
		tmp.SetActive (false);
		pooledObjects.Add (tmp);
		return tmp;
	}

}
