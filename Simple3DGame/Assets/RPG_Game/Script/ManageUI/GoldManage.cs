using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManage : MonoBehaviour {
	public static int goldCollection;
	Text curgold;

	// Use this for initialization
	void Start () {
		curgold = GetComponent<Text> ();
		goldCollection = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		curgold.text = goldCollection.ToString();
	}
}
