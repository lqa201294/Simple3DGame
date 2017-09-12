using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetItem : MonoBehaviour {

	public GameObject[] ItemHp;
	public GameObject[] ItemMp;
	public GameObject[] itemCoin;


	public SkillZ NumberHp;
	public SkillX NumberMp;

	public GameObject GetSwordEffect;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.B)) 
		{
			pickItem ();
		}
	}

	void pickItem()
	{
		ItemHp = GameObject.FindGameObjectsWithTag ("HpPotion");
		ItemMp = GameObject.FindGameObjectsWithTag ("MpPotion");
		itemCoin = GameObject.FindGameObjectsWithTag ("Coin");

		if (ItemHp.Length != 0)
		{
			NumberHp.GetHpPotion (ItemHp.Length);
			foreach (GameObject item in ItemHp) {
				Destroy (item);
			}

		
		}

		if (ItemMp.Length != 0) 
		{
			NumberMp.GetMpPotion (ItemMp.Length);
			foreach (GameObject item in ItemMp) 
			{
				Destroy (item);
			}

		}

		if (itemCoin.Length != 0) 
		{
			GoldManage.goldCollection += Random.Range (10, 100); 
			foreach (GameObject item in itemCoin) 
			{
				Destroy (item);
			}

		}

	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "sword") 
		{
			col.gameObject.GetComponent<BoxCollider> ().enabled = false;
			StartCoroutine (GetEffect (3f, CallSmileArea.area));
		}
	}

	IEnumerator GetEffect(float time , int area)
	{
		yield return new WaitForSeconds (time);
		GameObject go = (GameObject)Instantiate (GetSwordEffect);
		go.transform.SetParent (gameObject.transform, false);
	

		switch (area) 
		{
		case 0:
			ParticleSystem.MainModule setting	= GetSwordEffect.GetComponent<ParticleSystem> ().main;
			setting.startColor = Color.red;
			break;
		case 1:
			ParticleSystem.MainModule st	= GetSwordEffect.GetComponent<ParticleSystem> ().main;
			st.startColor = Color.green;
			break;
		case 2:
			ParticleSystem.MainModule setcolor	= GetSwordEffect.GetComponent<ParticleSystem> ().main;
			setcolor.startColor = Color.yellow;
			break;
		case 3:
			ParticleSystem.MainModule setcl	= GetSwordEffect.GetComponent<ParticleSystem> ().main;
			setcl.startColor = Color.white;
			break;

		}


	}



}
