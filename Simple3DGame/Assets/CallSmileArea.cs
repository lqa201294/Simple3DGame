using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSmileArea : MonoBehaviour {
	
	public GameObject[] MapArea;
	public static int area;

	// Use this for initialization
	void Start ()
	{
		area = 0;
		MapArea [area].SetActive (true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (HpSmile.clearArea) 
		{
			MapArea [area].SetActive (true);
			MapArea [area - 1].SetActive (false);
		}

	}
}
