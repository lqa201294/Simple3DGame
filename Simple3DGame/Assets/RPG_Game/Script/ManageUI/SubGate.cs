using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubGate : MonoBehaviour {
	public GameObject notify;
	public GameObject subgate;

	public void EnterGate()
	{
		subgate.transform.GetChild (CallSmileArea.area).gameObject.SetActive (false);
		notify.SetActive (false);
	}

	public void Back()
	{
		notify.SetActive (false);
	}

}
