using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target ;
	public float smoothing = 5f;

	Vector3 offset;

	public float minx;
	public float maxx;
	public float minz;
	public float maxz;

	Vector3 Limitcam;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 camtargetpos = target.position + offset;

		Limitcam.x = Mathf.Clamp (camtargetpos.x, minx, maxx);
		Limitcam.y = 20f;
		Limitcam.z = Mathf.Clamp (camtargetpos.z, minz, maxz);

		camtargetpos = Limitcam;

		transform.position = Vector3.Lerp (transform.position, camtargetpos, smoothing * Time.deltaTime);
	}
}
