using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDuration : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, 3f);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (0f,60f * speed *Time.deltaTime,0f);
	}
}
