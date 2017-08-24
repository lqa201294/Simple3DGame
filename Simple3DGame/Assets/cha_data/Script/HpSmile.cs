using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HpSmile : MonoBehaviour {
	public float SmileDefaultHP ;
	public float BossSmileHP ;
	public float CurrentSmileHP;

	public GameObject DestroyParticle;
	GameObject HPDisplay;
	Image hpsmile;
	Text showhp;

	public Camera m_camera;
	public GameObject[] Gate;

	public static bool clearArea;

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
		showhp = hpsmile.transform.GetChild (0).GetComponent<Text> ();

		SmileDefaultHP = float.Parse(ReadJsonData.itemdata ["Level"] [CallSmileArea.area]["Hp"].ToString());
		BossSmileHP = 4 * SmileDefaultHP; 

		if (gameObject.tag == "enemy")
		{
			
			CurrentSmileHP = SmileDefaultHP;

		} 
		else if (gameObject.tag == "Boss") 
		{
			
			StartPos = transform.position;

			CurrentSmileHP = BossSmileHP;
			gameObject.name = "Boss";
			gameObject.GetComponent<NavMeshAgent> ().speed = 4;
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
			StartCoroutine (HitDamaged(gameObject.transform.GetChild(0).gameObject, 3, 0.1f));

			if (gameObject.tag == "Boss") 
			{
				clearArea = true;
				CallSmileArea.area++;
			}
		}

		if (gameObject.tag == "Boss") 
		{
			hpsmile.fillAmount = CurrentSmileHP / BossSmileHP;
			showhp.text = CurrentSmileHP + "/" + BossSmileHP; 
		} 
		else 
		{
			hpsmile.fillAmount = CurrentSmileHP / SmileDefaultHP;
			showhp.text = CurrentSmileHP + "/" + SmileDefaultHP; 
		}


	}


	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "QSkill") 
		{
			CurrentSmileHP--;
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

		Instantiate (Gate[Random.Range(0,5)] , StartPos, Quaternion.identity);

		Destroy (gameObject);
	}


	public void TakeDamage()
	{
		CurrentSmileHP--;
		anim.SetTrigger ("damage");
	}
}
