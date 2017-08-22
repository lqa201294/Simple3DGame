using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManageEnemy : MonoBehaviour {

	public Healthplayer playerHealth;       // Reference to the player's heatlh.
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime = 1f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	public int numsmile;
	public int spawnPointIndex = 0;
	public Vector3 offset;
	public Transform BossPos;


	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", 0f, spawnTime);
		numsmile = 0;
	
	}

	void Update()
	{
		if (numsmile == 7) 
		{
			numsmile = 0;
			spawnPointIndex += 1;
		}

		if (spawnPointIndex >= spawnPoints.Length -1) 
		{
			spawnPointIndex = 0;
			CancelInvoke ();
			CallBoss ();
		}
	
	}

	void Spawn ()
	{
		offset = new Vector3 (Random.Range(1f,3f), 0f, Random.Range(1f, 2f));

		numsmile++;
		// If the player has no health left...
		if(playerHealth.curhealth <= 0f || numsmile == 10)
		{
			// ... exit the function.
			return;
		}
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy, spawnPoints[spawnPointIndex].position + offset, spawnPoints[spawnPointIndex].rotation);

	}


	void CallBoss()
	{
		GameObject go  = Instantiate (enemy , BossPos.position, Quaternion.identity);
		go.transform.localScale *= 2f; 
		go.gameObject.tag = "Boss";

	}


}
