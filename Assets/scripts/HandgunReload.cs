using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunReload : MonoBehaviour {

	public AudioSource reloadSound;
	public GameObject crossObject;

	private int clipCount, reserveCount, reloadAvail;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		clipCount = GlobalAmmo.loaded_ammo_pistol;
		reserveCount = GlobalAmmo.total_ammo_pistol;

		if (reserveCount == 0)
			reloadAvail = 0;
		else
			reloadAvail = 10 - clipCount;

		if (Input.GetButtonDown ("Reload") || clipCount == 0) {
			if (reloadAvail > 0) {
				if (reserveCount <= reloadAvail) {
					GlobalAmmo.loaded_ammo_pistol += reserveCount;
					GlobalAmmo.total_ammo_pistol -= reserveCount;
					reload ();
				} else {
					GlobalAmmo.loaded_ammo_pistol += reloadAvail;
					GlobalAmmo.total_ammo_pistol -= reloadAvail;
					reload ();
				}
			}
			StartCoroutine (endReload ());
		}
	}

	IEnumerator endReload() {
		yield return new WaitForSeconds (1.1f);
		this.GetComponent<GunFire> ().enabled = true;
		crossObject.SetActive (true);
	}

	void reload() {
		this.GetComponent<GunFire> ().enabled = false;
		crossObject.SetActive (false);
		reloadSound.Play ();
		this.GetComponent<Animation> ().Play ("reload");
	}
}
