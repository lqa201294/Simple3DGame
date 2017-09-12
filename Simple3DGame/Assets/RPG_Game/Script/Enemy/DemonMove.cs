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



	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		hpplayer = player.GetComponent<Healthplayer> ();

		anim = GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();

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
