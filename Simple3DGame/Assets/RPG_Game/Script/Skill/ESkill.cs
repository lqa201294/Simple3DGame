using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESkill : MonoBehaviour {
	public float speed = 2f;
	Vector3 direction;
	GameObject player;

	public GameObject destroyParticle;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");

		if (player.GetComponent<MovePlayer> ().movement != Vector3.zero)
		{
			direction = player.GetComponent<MovePlayer> ().movement;
		} 
			
	}

	void Start()
	{
		Destroy (gameObject, 2f);
	}

	void Update () 
	{
		transform.position += direction.normalized * speed * Time.deltaTime;
	}

}
