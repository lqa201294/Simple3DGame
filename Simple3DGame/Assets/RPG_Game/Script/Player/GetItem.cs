using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetItem : MonoBehaviour {

	public GameObject[] ItemHp;
	public GameObject[] ItemMp;
	public GameObject[] itemCoin;


	public SkillZ NumberHp;
	public SkillX NumberMp;

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



}
