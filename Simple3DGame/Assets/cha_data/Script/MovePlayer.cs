using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovePlayer : MonoBehaviour {
	public GameObject MinimapCam;
	public float speed = 6f;            // The speed that the player will move at.

	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

	bool turnleft;
	bool turnright;
	bool up;
	bool down;

	public GameObject SpawnPoint;
	public float distance;

	void Awake ()
	{
		// Set up references.
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	
	}


	void FixedUpdate ()
	{
		
		// Store the input axes.
		float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
		float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

		// Move the player around the scene.
		Move (h, v);

		if (Input.GetKeyDown (KeyCode.Tab)) 
		{
			MinimapCam.SetActive (true);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			MinimapCam.SetActive (false);
		}

		if(Input.GetKey(KeyCode.LeftArrow))
		{	
			transform.eulerAngles = new Vector3 (0f, -90f, 0f);

		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.eulerAngles = new Vector3 (0f, 90f, 0f);
		}

		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.eulerAngles = new Vector3 (0f, 0f, 0f);
		}

		if(Input.GetKey(KeyCode.DownArrow))
		{
			
			transform.eulerAngles = new Vector3 (0f, 180f, 0f);
		}

	
		// Animate the player.
		Animating (h, v);
	}



	void Move (float h, float v)
	{
		// Set the movement vector based on the axis input.
		movement.Set (h, 0f, v);

		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;

		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);
	}


	void Animating (float h, float v)
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		bool walking = h != 0f || v != 0f;

		// Tell the animator whether or not the player is walking.
		anim.SetBool ("IsWalking", walking);
	}
}
