using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HpSmile : MonoBehaviour {
	public float SmileDefaultHP = 1f;
	public float BossSmileHP = 10f;
	public float CurrentSmileHP;

	public GameObject DestroyParticle;
	GameObject HPDisplay;
	Image hpsmile;
	public Camera m_camera;
	public GameObject Gate;

	public static bool clearArea;
	bool isBoss;

	Animator anim;

	Vector3 StartPos;


	void Awake()
	{
		m_camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
	}

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();


		HPDisplay = transform.GetChild (2).gameObject;
		hpsmile = HPDisplay.transform.GetChild (0).GetComponent<Image> ();

		if (gameObject.tag == "enemy")
		{
			isBoss = false;
			CurrentSmileHP = SmileDefaultHP;

		} 
		else if (gameObject.tag == "Boss") 
		{
			isBoss = true;
			StartPos = transform.position;

			CurrentSmileHP = BossSmileHP;
			gameObject.name = "Boss";
			gameObject.GetComponent<NavMeshAgent> ().speed = 3;
		}
		

		clearArea = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (m_camera != null) 
		{
			HPDisplay.transform.LookAt(transform.position + m_camera.transform.rotation * Vector3.forward,
				m_camera.transform.rotation * Vector3.up);
		}


		if (CurrentSmileHP == 0 && clearArea == false) 
		{
			clearArea = true;
			CallSmileArea.area++;

			DestroyEffect ();
		}

		if (gameObject.tag == "Boss") 
		{
			hpsmile.fillAmount = CurrentSmileHP / BossSmileHP;
		} 
		else 
		{
			hpsmile.fillAmount = CurrentSmileHP / SmileDefaultHP;
		}


	}


	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "QSkill") 
		{
			if (isBoss) 
			{
				CurrentSmileHP--;
			}
			else
			{
				StartCoroutine (HitDamaged(gameObject.transform.GetChild(0).gameObject, 3, 0.1f));
			}

		}
	}


	IEnumerator HitDamaged(GameObject skin, float ntime, float time)
	{
		while (ntime > 0) 
		{
			skin.GetComponent<SkinnedMeshRenderer> ().enabled = false;
			yield return new WaitForSeconds (time);
			skin.GetComponent<SkinnedMeshRenderer> ().enabled = true;
			yield return new WaitForSeconds (time);
			ntime--;

			if (ntime == 0) 
			{				
					DestroyEffect ();
			}
		}
	}


	void DestroyEffect()
	{
		ScoreManage.Score += 1;
		ParticleSystem.MainModule setting = DestroyParticle.GetComponent<ParticleSystem> ().main;
		setting.startColor = Color.white;

		Instantiate (DestroyParticle, transform.position, Quaternion.Euler(-90f,0f,0f));

		Instantiate (Gate , StartPos, Quaternion.identity);

		Destroy (gameObject);
	}


	public void TakeDame()
	{
		CurrentSmileHP--;
		anim.SetTrigger ("damage");
	}
}
