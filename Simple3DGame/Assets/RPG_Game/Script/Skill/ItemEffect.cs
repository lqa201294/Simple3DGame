using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour {
	public GameObject effect;

	// Use this for initialization
	void Start () {

		Instantiate (effect, transform.position, Quaternion.identity);
	}

}
