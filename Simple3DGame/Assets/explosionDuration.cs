using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDuration : MonoBehaviour {
	GameObject enemy;
	// Use this for initialization
	void Start () {
		StartCoroutine (destroyself(2f));
	}
		
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "enemy") 
		{
			enemy = col.gameObject;
			InvokeRepeating ("explosion",0, 1);
		}
	}

	void explosion()
	{
		if (enemy != null) 
		{
			enemy.GetComponent<HpSmile> ().TakeDamage (1);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "enemy") 
		{
			CancelInvoke ();
		}
	}

	IEnumerator destroyself(float time)
	{
		yield return new WaitForSeconds (time);
		CancelInvoke ();
		Destroy (gameObject);
	}
}
