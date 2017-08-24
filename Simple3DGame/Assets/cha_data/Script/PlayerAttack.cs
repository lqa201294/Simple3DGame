using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {
	Animator anim;
	bool attack;
	bool colEnemy;


	GameObject enemy;
	public GameObject slashLight;
	public GameObject smileparticle;


	Vector3 dir;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.Space) ||Input.GetKeyDown(KeyCode.Q))
		{
			attack = true;
			anim.SetBool ("Attack", attack);

		}
		else
		{
			attack = false;
			anim.SetBool ("Attack", attack);
		}


		if (attack && colEnemy && enemy!=null) 
		{
			colEnemy = false;
			enemy.GetComponent<HpSmile>().TakeDamage();

		}


	}
		
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "enemy" || col.gameObject.tag == "Boss" ) 
		{
			dir = col.transform.position - transform.position;
			if (Vector3.Dot (dir, transform.forward) > 0.3f) 
			{
				enemy = col.gameObject;
				colEnemy = true;
			}
		}


	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "enemy") 
		{
			colEnemy = false;
		}

	}

	public void SlashEffectStart()
	{
		slashLight.SetActive (true);
	}

	public void SlashEffectEnd()
	{
		slashLight.SetActive (false);
	}


}
