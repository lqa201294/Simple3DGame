using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour {
	public static string ItemName;
	public static int Price;
	public GameObject BuyNotify;


	public void Buy(string name)
	{
		ItemName = name;

		if (name == "HpItem")
		{
			Price = 30;	
		}
		else if (name == "MpItem") 
		{
			Price = 20;
		}

		BuyNotify.SetActive (true);

	}

}
