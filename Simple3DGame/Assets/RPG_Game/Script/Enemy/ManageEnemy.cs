using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManageEnemy : MonoBehaviour {

	public Healthplayer playerHealth;       
	public GameObject enemy;                

	public Transform[] spawnPoints;         
	public Vector3 offset;
	public Transform BossPos;

	public int numsmile;
	public int spawnPointIndex = 0;
	public float spawnTime = 1f;      
	public int totalscore;

	public GameObject Demon;
	public GameObject Gate;
	public Transform subBossPos;


	bool callboss;
	bool callsubboss;

	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", 0f, spawnTime);
		numsmile = 0;
	
		callboss = false;
		callsubboss = false;

		totalscore = 7 * spawnPoints.Length ;
	}

	void Update()
	{
		if (numsmile == 7) 
		{
			numsmile = 0;
			spawnPointIndex += 1;
		}

		if (spawnPointIndex > spawnPoints.Length -1) 
		{
			spawnPointIndex = 0;
			CancelInvoke ();
		}

		if (ScoreManage.Score == totalscore && callboss == false) 
		{
			callboss = true;
			CallBoss ();
		}

		if (ScoreManage.Score >= totalscore / 3 && callsubboss == false) 
		{
			callsubboss = true;
			CallDemon ();

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

	void CallDemon ()
	{
		Gate.SetActive (true);
		Instantiate (Demon , subBossPos.position, Quaternion.identity);
	}

	void CallBoss()
	{
		GameObject go  = Instantiate (enemy , BossPos.position, Quaternion.identity);
		go.transform.localScale *= 2f; 
		go.gameObject.tag = "Boss";

	}


}
