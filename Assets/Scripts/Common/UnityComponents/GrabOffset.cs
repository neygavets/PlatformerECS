using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabOffset : MonoBehaviour {
	[SerializeField] Transform linkPoint;

	void Start () {
		transform.localPosition = Vector3.zero - linkPoint.localPosition;
		transform.localRotation = Quaternion.identity;
	}
}
