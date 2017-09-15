using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {
	Animator anim;
	bool attack;
	bool colEnemy;
	bool colsubboss;

	public float Plattackdame;

	GameObject enemy;
	GameObject subBoss;

	public GameObject slashLight;
	public GameObject smileparticle;


	Vector3 dir;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		Plattackdame = float.Parse (ReadJsonData.itemdata["Level"][CallSmileArea.area]["attackdame"].ToString());
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.Space))
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
			enemy.GetComponent<HpSmile>().TakeDamage(Plattackdame);

		}

		if (attack && colsubboss && subBoss!=null) 
		{
			colsubboss = false;
			subBoss.GetComponent<HpDemon>().GetDamage(Plattackdame);
		
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

		if (col.gameObject.tag == "subBoss") 
		{
			dir = col.transform.position - transform.position;
			if (Vector3.Dot (dir, transform.forward) > 0.3f) 
			{
				subBoss = col.gameObject;
				colsubboss = true;

			}
		
		}

	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "enemy") 
		{
			colEnemy = false;
		}

		if (col.gameObject.tag == "subBoss") 
		{
			colsubboss = false;
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
