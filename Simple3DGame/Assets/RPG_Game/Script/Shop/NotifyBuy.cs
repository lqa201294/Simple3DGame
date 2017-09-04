using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NotifyBuy : MonoBehaviour {
	public Text Notify;
	public Text Cost;
	public InputField numberInput;

	public int defaultNum;
	public int totalCost;

	// Use this for initialization
	void Start () 
	{
		Notify.text = "Are you sure to buy?" + " " + "\n" + "Item:" + " "
		+ BuyItem.ItemName + "\n" + "Price:" + " " + BuyItem.Price +"/1b";

		defaultNum = 1;
		numberInput.text = defaultNum.ToString ();
	}

	void Update()
	{
		if (numberInput.text != "")
		{
			defaultNum = Int32.Parse (numberInput.text);
		}
		else
		{
			defaultNum = 0;
		}

		totalCost = defaultNum * BuyItem.Price;

		Cost.text = "Total Cost:" +" " + totalCost.ToString();
	}
}
