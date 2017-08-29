using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPlayer : MonoBehaviour {
	public float maxMana = 50f;
	public float curMana ;

	public GameObject ManaStatus;
	public GameObject ManaRecoverParticle;
	public Text curstatus;

	// Use this for initialization
	void Start () {
		curMana = 50f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		ManaStatus.GetComponent<Slider> ().value = curMana / maxMana;
		curstatus.text = curMana + "/" + maxMana;
	}

	public void SpendMana(float ManaCost)
	{
		curMana -= ManaCost;
	}
	public void ManaRecover(float amount)
	{
		ParticleSystem.MainModule setting = ManaRecoverParticle.GetComponent<ParticleSystem> ().main;
		setting.startColor = Color.blue + new Color(.5f,.5f, 0f,0f);

		GameObject go = (GameObject)Instantiate (ManaRecoverParticle, transform.position + new Vector3(0f,1f,0f), Quaternion.identity);
		go.transform.SetParent (gameObject.transform);
		go.transform.eulerAngles = new Vector3 (-90f,0f,0f);
		go.transform.localScale = new Vector3 (5f,5f,5f);
		curMana += amount;

	}
}
