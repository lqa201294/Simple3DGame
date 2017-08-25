using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPlayer : MonoBehaviour {
	public float maxMana = 50f;
	public float curMana ;

	public GameObject ManaStatus;
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
		curMana += amount;
	}
}
