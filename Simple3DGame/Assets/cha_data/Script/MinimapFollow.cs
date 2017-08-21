using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollow : MonoBehaviour {
	public Transform target ;
	public float smoothing = 5f;


	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCamPos = target.position;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

	}
}
