using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMinimapCam : MonoBehaviour {

	public float minX;
	public float maxX;
	public float minZ;
	public float maxZ;

	Vector3 position;

	// Use this for initialization
	void Start () {
		position = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		position.x = Mathf.Clamp (transform.position.x, minX, maxX);
		position.z = Mathf.Clamp (transform.position.z, minZ, maxZ);

		transform.position = position;
	}
}
