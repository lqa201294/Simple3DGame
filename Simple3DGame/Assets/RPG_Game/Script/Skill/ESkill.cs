using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESkill : MonoBehaviour {
	public float speed = 2f;
	GameObject player;
	Vector3 direction;

	float skilldame;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		direction = player.transform.forward;

	}

	void Start()
	{
		Destroy (gameObject, 2f);

		skilldame = player.GetComponent<PlayerAttack> ().Plattackdame;
	}

	void Update () 
	{
		transform.position +=  direction * speed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "enemy") 
		{
			col.GetComponent<HpSmile> ().TakeDamage (skilldame);
		}
	}

}
