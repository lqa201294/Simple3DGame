using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDuration : MonoBehaviour {

	public float speed;
	public float duration;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (DestroyShield(duration));
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (0f,60f * speed *Time.deltaTime,0f);
	}

	IEnumerator DestroyShield(float time)
	{
		yield return new WaitForSeconds (time);
		SkillV.absorbDamage = false;
		Destroy (gameObject);
	}
}
