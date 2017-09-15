using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyBuy : MonoBehaviour {
	public GameObject BuyNotify;
	public GoldManage gold;
	public NotifyBuy nbuy;
	public SkillZ CurHPpotion;
	public SkillX CurMppotion;

	public GameObject BillNotify;

	public void Apply()
	{
		if (nbuy.totalCost <= GoldManage.goldCollection)
		{
			if (BuyItem.ItemName == "HpItem") 
			{
				CurHPpotion.GetHpPotion (nbuy.defaultNum);
			}
			else if (BuyItem.ItemName == "MpItem") 
			{
				CurMppotion.GetMpPotion (nbuy.defaultNum);
			}

			gold.spendGold (nbuy.totalCost);
			BuyNotify.SetActive (false);
		}
		else
		{
			BillNotify.SetActive (true);
			BillNotify.transform.GetChild (1).GetComponent<Button> ().onClick.AddListener (ok);
		}
			
	}

	public void Back()
	{
		BuyNotify.SetActive (false);
	}

	public void ok()
	{
		BillNotify.SetActive (false);
	}

}
