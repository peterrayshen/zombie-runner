using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG_Reload : MonoBehaviour {

	public AudioSource reloadSound;

	private int clipCount, reserveCount, reloadAvail;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		clipCount = GlobalAmmo.loaded_ammo_smg;
		reserveCount = GlobalAmmo.total_ammo_smg;

		if (reserveCount == 0)
			reloadAvail = 0;
		else
			reloadAvail = 30 - clipCount;

		if (Input.GetButtonDown ("Reload") || clipCount == 0) {
			if (reloadAvail > 0) {
				if (reserveCount <= reloadAvail) {
					GlobalAmmo.loaded_ammo_smg += reserveCount;
					GlobalAmmo.total_ammo_smg -= reserveCount;
					reload ();
				} else {
					GlobalAmmo.loaded_ammo_smg += reloadAvail;
					GlobalAmmo.total_ammo_smg -= reloadAvail;
					reload ();
				}
			}
			StartCoroutine (endReload ());
		}
	}

	IEnumerator endReload() {
		yield return new WaitForSeconds (2.2f);
		this.GetComponent<GunFireSMG> ().enabled = true;
	}

	void reload() {
		this.GetComponent<GunFireSMG> ().enabled = false;
		reloadSound.Play ();
		this.GetComponent<Animation> ().Play ("reload_smg");
	}
}
