using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonMove : MonoBehaviour {

	NavMeshAgent nav;
	public float distance;
	GameObject player;
	Healthplayer hpplayer;
	Animator anim;
	public float turnspeed;

	bool moving;
	bool colplayer;

	public GameObject demonEffect;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		hpplayer = player.GetComponent<Healthplayer> ();

		anim = GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();


		GameObject go = (GameObject)Instantiate (demonEffect);
		go.transform.SetParent (gameObject.transform, false);
		go.transform.localRotation = Quaternion.Euler (-90,0,0);
		go.transform.localScale = new Vector3 (3,3,6);

		switch (CallSmileArea.area) 
		{
		case 0: 
			ParticleSystem.MainModule setting	= go.GetComponent<ParticleSystem> ().main;
			setting.startColor = Color.green;
			break;
		case 1:
			ParticleSystem.MainModule setcolor	= go.GetComponent<ParticleSystem> ().main;
			setcolor.startColor = Color.cyan;
			break;
		case 2:
			ParticleSystem.MainModule set	= go.GetComponent<ParticleSystem> ().main;
			set.startColor = Color.white;
			break;
		case 3:
			ParticleSystem.MainModule setcl	= go.GetComponent<ParticleSystem> ().main;
			setcl.startColor = Color.red;
			break;
		}


	}
	
	// Update is called once per frame
	void Update () 
	{
		distance = Vector3.Distance (transform.position, player.transform.position);

		if (hpplayer.curhealth > 0 && distance < 30f && colplayer == false) 
		{
			Moving ();
		}
	
	}

	void Moving()
	{
		moving = true;
		nav.SetDestination (player.transform.position);
		anim.SetBool ("walking", moving);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			colplayer = true;
			nav.enabled = false;
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Player") 
		{
			transform.rotation = Quaternion.Slerp (transform.rotation, 
				Quaternion.LookRotation(col.transform.position - transform.position),turnspeed * Time.deltaTime);
		}
	}


	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player") 
		{
			colplayer = false;
			nav.enabled = true;
		}
	}

	void ChangeStatus()
	{
		moving = false;
		anim.SetBool ("walking", moving);
	}

}
