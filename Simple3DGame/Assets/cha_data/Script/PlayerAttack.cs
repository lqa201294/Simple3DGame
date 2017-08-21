using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {
	Animator anim;
	bool attack;
	bool colEnemy;
	bool colBoss;

	GameObject enemy;
	GameObject Boss;
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
			StartCoroutine (Flicker(enemy,3,0.1f));
			enemy.GetComponent<SphereCollider> ().enabled = false;
		}

		if (colBoss && attack && Boss !=null) 
		{
			Boss.GetComponent<HpSmile>().TakeDame();
		}


	}
		
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "enemy" ) 
		{
			dir = col.transform.position - transform.position;
			if (Vector3.Dot (dir, transform.forward) > 0.3f) 
			{
				enemy = col.gameObject;
				colEnemy = true;
			}
		}

		if (col.gameObject.tag == "Boss") 
		{
			colBoss = true;
			Boss = col.gameObject;
		}


	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "enemy") 
		{
			colEnemy = false;
		}

		if (col.gameObject.tag == "Boss") 
		{
			colBoss = false;
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

	IEnumerator Flicker(GameObject smile, float ntime, float time)
	{
		while (ntime > 0) 
		{
			smile.SetActive (false);
			yield return new WaitForSeconds (time);
			smile.SetActive (true);
			yield return new WaitForSeconds (time);
			ntime--;

			if (ntime == 0) 
			{
				ScoreManage.Score += 1;
				ParticleSystem.MainModule setting = smileparticle.GetComponent<ParticleSystem> ().main;
				setting.startColor = Color.white;

				Instantiate (smileparticle, enemy.transform.position, Quaternion.Euler(-90f,0f,0f));

				Destroy (smile);
			}
		}

	}
}
