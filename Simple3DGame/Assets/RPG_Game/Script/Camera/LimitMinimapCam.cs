using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMinimapCam : MonoBehaviour {

	public float minX;
	public float maxX;
	public float minZ;
	public float maxZ;

	Vector3 position;

	public Transform target ;
	public float smoothing = 5f;

	// Update is called once per frame
	void Update () 
	{

		position.x = Mathf.Clamp (target.position.x, minX, maxX);
		position.y = 70f;
		position.z = Mathf.Clamp (target.position.z, minZ, maxZ);

		transform.position = position;

	}
}
