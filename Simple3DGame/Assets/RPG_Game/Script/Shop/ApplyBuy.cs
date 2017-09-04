using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyBuy : MonoBehaviour {
	public GameObject BuyNotify;
	public GoldManage gold;
	public NotifyBuy nbuy;
	public SkillZ CurHPpotion;
	public SkillX CurMppotion;

	public void Apply()
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

	public void Back()
	{
		BuyNotify.SetActive (false);
	}


}
