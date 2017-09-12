using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiteffectDuration : MonoBehaviour {
	GameObject enemy;

	// Use this for initialization
	void Start () {
		StartCoroutine (destroyself(2f));

		switch (CallSmileArea.area) 
		{
		case 0: 
			Color fire = new Color (1f, 0.3f, 0f, 1f);
			ParticleSystem.MainModule setting = GetComponent<ParticleSystem> ().main;
			setting.startColor = fire;
			break;
		}
	}

	IEnumerator destroyself(float time)
	{
		yield return new WaitForSeconds (time);
		CancelInvoke ();
		Destroy (gameObject);
	}



	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "enemy") 
		{
			enemy = col.gameObject;
			InvokeRepeating ("BurnIt", 0, 1);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "enemy") 
		{
			CancelInvoke ();
		}
	}


	void BurnIt()
	{
		if (enemy != null) 
		{
			enemy.GetComponent<HpSmile> ().TakeDamage (1);
		}
	
	}

}
