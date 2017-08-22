using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthplayer : MonoBehaviour {
	public float startHealth = 100;
	public float curhealth;
	public float timedelay;
	public float maxtimedelay = 20f;
	public float healthrecover = 20;

	public float speedLerp = 3f;

	public Slider healthbar;
	public GameObject HealthSkilParticle;
	public Text StatusHP;
	public Text GameOver;

	public SkillE castshield;
	GameObject enemy;

	Animator anim;


	// Use this for initialization
	void Awake ()
	{
		timedelay = 0;
		curhealth = startHealth;
		anim = GetComponent<Animator> ();
		healthbar.GetComponent<Slider> ().value = 1;

		StatusHP.GetComponent<Text> ().text = "";
	}

	void Update()
	{
		if (timedelay > 0) 
		{
			timedelay -= Time.deltaTime;

		}

		if (curhealth > 100) 
		{
			curhealth = startHealth;
		}

		if (curhealth < 0) 
		{
			curhealth = 0;
		}
			
		healthbar.GetComponent<Slider> ().value = curhealth / startHealth;
		StatusHP.GetComponent<Text> ().text = curhealth + "/" + startHealth;


	}
	

	public void takedamaged(float amount)
	{
		curhealth -= amount;
		anim.SetTrigger ("Damage");

		if (curhealth <= 0) 
		{
			PlayerDead ();
		}	
	
	}

	void OnTriggerEnter(Collider col)
	{
		enemy = col.gameObject;

		if (castshield.absorbDamage) 
		{
			enemy.GetComponent<SmileAttack>().attackDamage = 0f;
		} 
		else 
		{
			if (enemy.tag == "enemy") 
			{
				enemy.GetComponent<SmileAttack> ().attackDamage = 1f;
			}
			else if (enemy.tag == "Boss")
			{
				enemy.GetComponent<SmileAttack> ().attackDamage = 5f;
			}
		}
	}

	void PlayerDead()
	{
		anim.SetTrigger ("Dead");

		GameOver.enabled = true;
		Color startcolor = new Color (0,0,0,0);
		Color endcolor = new Color (0,0,0,1);
		GameOver.GetComponent<Text> ().color = Color.Lerp (startcolor , endcolor ,speedLerp* Time.deltaTime);


	}

	public void RecoverHealth(float amount)
	{
		timedelay = maxtimedelay;
		ParticleSystem.MainModule setting = HealthSkilParticle.GetComponent<ParticleSystem> ().main;
		setting.startColor = Color.green;

	
		GameObject go = (GameObject)Instantiate (HealthSkilParticle, transform.position + new Vector3(0f,1f,0f), Quaternion.identity);
		go.transform.SetParent (gameObject.transform);
		go.transform.eulerAngles = new Vector3 (-90f,0f,0f);
		go.transform.localScale = new Vector3 (5f,5f,5f);

		curhealth += amount;


	}
}
