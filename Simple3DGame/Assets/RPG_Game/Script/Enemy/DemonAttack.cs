using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonAttack : MonoBehaviour {
	public float timeperAttack = 1.5f;
	public float Attackdame ;

	public float IncreaseAttack;
	float timer;


	Animator anim;
	GameObject Player;
	bool canAttack;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Player = GameObject.FindGameObjectWithTag ("Player");

		Attackdame = 3* float.Parse(ReadJsonData.itemdata ["Level"] [CallSmileArea.area]["attackdame"].ToString());
		IncreaseAttack = Attackdame * 1.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer +=Time.deltaTime;

		if (timer > timeperAttack && canAttack && Player.GetComponent<Healthplayer> ().curhealth > 0) 
		{
			Attack ();
		}

		if (Player.GetComponent<Healthplayer> ().curhealth <= 0) 
		{
			anim.Play ("Idle");
			Player.GetComponent<MovePlayer> ().enabled = false;
			Player.GetComponent<PlayerAttack>().enabled = false;
		}


		if (SkillV.absorbDamage) 
		{
			Attackdame = 0f;
		}
		else
		{
			
			if (HpDemon.fury) 
			{
				Attackdame = IncreaseAttack;
				HpDemon.fury = false;
			}
			else
			{
				Attackdame = 3* float.Parse(ReadJsonData.itemdata ["Level"] [CallSmileArea.area]["attackdame"].ToString());
			}

		}

	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject == Player) 
		{
			Vector3 dir = col.transform.position - transform.position;
			if (Vector3.Dot (dir, transform.forward) > 0.3f) 
			{
				canAttack = true;
			}

		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject == Player) 
		{
			Vector3 dir = col.transform.position - transform.position;
			if (Vector3.Dot (dir, transform.forward) > 0.3f) 
			{
				canAttack = true;
			}

		}
	}


	void OnTriggerExit(Collider col)
	{
		if (col.gameObject == Player) 
		{
			canAttack = false;

		}
	}

	void Attack()
	{
		timer = 0f;	
		anim.SetBool ("attack", canAttack);
	}

	void Attack2()
	{
		timer = 0f;	
		anim.SetBool ("attack2", canAttack);
	}

	public void AttackStatus()
	{
		anim.SetBool ("attack", canAttack);
		Player.GetComponent<Healthplayer> ().takedamaged (Attackdame);
	}

}
