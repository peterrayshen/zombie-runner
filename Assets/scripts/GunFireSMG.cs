using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireSMG : MonoBehaviour {

	public GameObject flash;
	public GameObject muzzle_light;
	public GameObject firePoint;

	public int damage = 12;

	private int ammoCount;

	public float roundsPerMinute = 750f;
	private float timePassed = 0f;


	// Use this for initialization
	void Start () {
		muzzle_light.SetActive (false);
		flash.GetComponent<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
		bool rateReset = timePassed > 1 / (roundsPerMinute / 60f);

		if (Input.GetButton ("Fire1") && GlobalAmmo.loaded_ammo_smg > 0 && rateReset) {
			RaycastHit shot = new RaycastHit();
			if (Physics.Raycast(firePoint.transform.position, firePoint.transform.TransformDirection(Vector3.forward), out shot)) 
				shot.transform.SendMessage("takeDamage", damage);
			AudioSource gunSound = GetComponent<AudioSource> ();
			gunSound.Play ();
			muzzleOn ();
			GetComponent<Animation> ().Stop("smg_shot");
			GetComponent<Animation> ().Play ("smg_shot");
			GlobalAmmo.loaded_ammo_smg -= 1;
			timePassed = 0;
		} 
	}

	void muzzleOn() {
		flash.GetComponent<Renderer> ().enabled = true;
		muzzle_light.SetActive (true);
		StartCoroutine (muzzleOff());
	}

	IEnumerator muzzleOff() {
		yield return new WaitForSeconds (0.05f);
		flash.GetComponent<Renderer> ().enabled = false;
		muzzle_light.SetActive (false);
	}
}
