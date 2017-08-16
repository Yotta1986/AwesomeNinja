using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform targetToFollow;
	public Vector3 cameraRig = new Vector3 (3f, 7.5f, -3f);

	void Start () {
		
	}

	void Update () {
		if (targetToFollow) {
			transform.position = targetToFollow.position + cameraRig;
			//transform.LookAt (targetToFollow);
		}
	}
}
