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
	public GameObject GameOver;
	GameObject DemonAura;

	Animator anim;
	bool colAura;

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

		if (DemonAura == null && colAura) 
		{
			colAura = false;
			CancelInvoke ();
		}
	}
		

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Aura") 
		{
			DemonAura = col.gameObject;
			colAura = true;
			InvokeRepeating ("PoisonAura", 0, 1.5f);
		}

		if (col.tag == "angel") 
		{
			InvokeRepeating ("HPRegen", 0, 1);
		
		}

	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Aura") 
		{
			colAura = false;
			CancelInvoke ();
		}

		if (col.tag == "angel") 
		{
			CancelInvoke ();
		}
	}

	void HPRegen()
	{
		if (curhealth < startHealth)
		{
			RecoverHealth (1);
		}
		else
		{
			RecoverHealth (0);
		}
	}

	void PoisonAura()
	{
		takedamaged (1);
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

	void PlayerDead()
	{
		anim.SetTrigger ("Dead");

		GameOver.SetActive (true);
		GameOver.GetComponent<Text> ().text = "Game Over";

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
