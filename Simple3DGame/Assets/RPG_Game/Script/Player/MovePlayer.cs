using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	public GameObject MinimapCam;
	public GameObject Shop;
	public GameObject Notify;

	public float speed = 6f;            // The speed that the player will move at.

	public Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

	Vector3 limitTranform;

	bool turnleft;
	bool turnright;
	bool up;
	bool down;

	public float xmin;
	public float xmax;
	public float zmin;
	public float zmax;

	public GameObject SpawnPoint;
	public GameObject AreaPos;

	void Awake ()
	{
		// Set up references.
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	
		limitTranform = gameObject.transform.position;
	}


	void FixedUpdate ()
	{

		// Store the input axes.
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
	
		movement = new Vector3 (h, 0f, v);
		if (movement != Vector3.zero) 
		{
			transform.rotation = Quaternion.Slerp (transform.rotation ,Quaternion.LookRotation(movement.normalized),0.2f);
		}
			
		transform.Translate (movement * speed * Time.deltaTime,Space.World);
	
		limitTranform.x = Mathf.Clamp (transform.position.x, xmin, xmax);
		limitTranform.z = Mathf.Clamp (transform.position.z ,zmin , zmax);

		transform.position = limitTranform;

		if (Input.GetKeyDown (KeyCode.Tab)) 
		{
			if (MinimapCam.activeSelf == true)
			{
				MinimapCam.SetActive (false);
			}
			else
			{
				MinimapCam.SetActive (true);
			}

		}

		// Animate the player.
		Animating (h, v);
	}
		



	void Animating (float h, float v)
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		bool walking = h != 0f || v != 0f;

		// Tell the animator whether or not the player is walking.
		anim.SetBool ("IsWalking", walking);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Gate") 
		{
			StartCoroutine (DestroyGate(col.gameObject,1f));
		}

		if (col.tag == "subGate") 
		{
			Notify.SetActive (true);
		}

		if (col.tag == "shop") 
		{
			Shop.SetActive (true);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "shop") 
		{
			Shop.SetActive (false);
		}
	}


	IEnumerator DestroyGate(GameObject Gate,float time)
	{
		yield return new WaitForSeconds (time);
		transform.position = AreaPos.transform.GetChild (CallSmileArea.area).transform.position; 
		yield return new WaitForSeconds (time);
		Destroy (Gate);
	}
}
