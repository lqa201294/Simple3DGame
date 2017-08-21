using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QSkill : MonoBehaviour {
	public float speed = 2f;
	Vector3 direction;
	GameObject player;

	public GameObject destroyParticle;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start()
	{
		Destroy (gameObject, 2f);
	
		if (player.transform.eulerAngles.y == 0) {
			direction = Vector3.forward;
		} else if (player.transform.eulerAngles.y == 90) {
			direction = Vector3.right;
		} else if (player.transform.eulerAngles.y == 180) {
			direction = Vector3.back;
		} else if (player.transform.eulerAngles.y == 270) 
		{
			direction = Vector3.left;
		}
	}

	void Update () 
	{

		transform.position += direction * speed * Time.deltaTime;
	}

}
