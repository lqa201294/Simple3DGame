﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileAttack : MonoBehaviour {
	public float timeperAttack = 1.5f;
	public float attackDamage = 1;
	public float BossAttack = 5;

	float timer;
	GameObject player;
	Animator anim;
	Healthplayer plhealth;
	bool inRange;

	public GameObject DestroyParticle;

	// Use this for initialization
	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		plhealth = player.GetComponent<Healthplayer> ();

		anim = GetComponent<Animator> ();

		if (gameObject.tag == "Boss") 
		{
			attackDamage = BossAttack;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if (timer > timeperAttack && inRange && plhealth.curhealth > 0)
		{
			Attack ();
		}

		if (plhealth.curhealth <= 0) 
		{
			anim.SetTrigger ("playerDead");
			player.GetComponent<MovePlayer> ().enabled = false;
			player.GetComponent<PlayerAttack>().enabled = false;
		}

	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject == player) 
		{
			inRange = true;

		}

	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject == player) 
		{
			inRange = false;
		}
	}

	void Attack()
	{
		timer = 0f;
		anim.SetBool ("attack",inRange);
	}

	public void changestat()
	{
		anim.SetBool ("attack",inRange);
		plhealth.takedamaged (attackDamage);
	
	}


	
}
