using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESkill : MonoBehaviour {
	public float speed = 2f;
	GameObject player;
	Vector3 direction;


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		direction = player.transform.forward;
	}

	void Start()
	{
		Destroy (gameObject, 2f);
	}

	void Update () 
	{
		transform.position +=  direction * speed * Time.deltaTime;
	}

}
