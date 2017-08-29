using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmileMove : MonoBehaviour {

	NavMeshAgent nav; 
	Transform player;
	Healthplayer healthpl;
	public float distance;


	// Use this for initialization
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		healthpl = player.GetComponent<Healthplayer> ();
		nav = GetComponent<NavMeshAgent> ();


	}
	
	// Update is called once per frame
	void Update () 
	{
		distance = Vector3.Distance (transform.position, player.position);

		if (healthpl.curhealth > 0 && distance < 30f ) 
		{
			nav.SetDestination (player.position);
			
		}

	}
}
