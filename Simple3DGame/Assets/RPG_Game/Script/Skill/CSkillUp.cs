using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSkillUp : MonoBehaviour {
	GameObject Player;
	float skilldamage;
	public GameObject effect;
	public GameObject explosion;

	// Use this for initialization

	void Awake()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
		skilldamage = Player.GetComponent<PlayerAttack> ().Plattackdame;
	}

	void Start()
	{
		switch (CallSmileArea.area) 
		{
		case 0:
			Color fire = new Color (1f, 0.3f, 0f, 1f);
			ParticleSystem.TrailModule setTrail = GetComponent<ParticleSystem> ().trails;
			setTrail.colorOverTrail = Color.Lerp (Color.clear, fire, 1f);

			break;

		case 1:
			ParticleSystem.TrailModule set = GetComponent<ParticleSystem> ().trails;
			set.colorOverTrail = Color.Lerp (Color.clear, Color.green, 1f);
			break;

		case 2:
			ParticleSystem.TrailModule trail = GetComponent<ParticleSystem> ().trails;
			trail.colorOverTrail = Color.Lerp (Color.clear, Color.yellow, 1f);
			break;
		case 3:
			ParticleSystem.TrailModule trailcolor = GetComponent<ParticleSystem> ().trails;
			trailcolor.colorOverTrail = Color.Lerp (Color.clear, Color.white, 1f);
			break;
		}


	}

	void OnParticleCollision(GameObject col)
	{
		col.GetComponentInParent<HpSmile> ().TakeDamage (skilldamage);

		if (CallSmileArea.area <= 1) 
		{
			Instantiate (effect, col.transform.transform.position, Quaternion.Euler (-90f, 0f, 0f));

		}
		else if (CallSmileArea.area == 2) 
		{
			Instantiate (explosion, col.transform.transform.position, Quaternion.Euler (-90f, 0f, 0f));
		}

		Destroy (gameObject);

	}



}
