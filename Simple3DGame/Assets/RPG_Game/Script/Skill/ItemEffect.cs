using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEffect : MonoBehaviour {
	public GameObject effect;
	public GameObject EvolveParticle;

	// Use this for initialization
	void Start () {

		Instantiate (effect, transform.position, Quaternion.identity);

		switch (CallSmileArea.area) 
		{
		case 0:
			ParticleSystem.MainModule setting	= transform.GetChild (1).GetComponent<ParticleSystem> ().main;
			setting.startColor = Color.red;
			break;

		case 1:
			ParticleSystem.MainModule st = transform.GetChild (1).GetComponent<ParticleSystem> ().main;
			st.startColor = Color.green;
			break;
		case 2:
			
			ParticleSystem.MainModule setcolor = transform.GetChild (1).GetComponent<ParticleSystem> ().main;
			setcolor.startColor = Color.yellow;
			break;

		case 3: 
			ParticleSystem.MainModule setcl = transform.GetChild (1).GetComponent<ParticleSystem> ().main;
			setcl.startColor = Color.blue;
			break;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{	
			StartCoroutine (Evolve(2f , col.gameObject));

		}
	}

	IEnumerator Evolve(float time, GameObject Player)
	{
		Instantiate (EvolveParticle, Player.transform.position, Quaternion.Euler(-90f,0,0));

		Player.GetComponent<MovePlayer> ().enabled = false;

		yield return new WaitForSeconds (time);

		Player.GetComponent<MovePlayer> ().enabled = true;
		Destroy (effect);
		Destroy (gameObject);
	}
}
