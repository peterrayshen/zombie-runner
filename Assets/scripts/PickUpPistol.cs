using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPistol : MonoBehaviour {

	private float distance = PlayerCasting.distanceFromTarget;
	public GameObject textDisplay;

	public GameObject fakeGun;
	public GameObject realGun;
	public GameObject ammoDisplay;

	public GameObject weaponController;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseOver() {
		distance = PlayerCasting.distanceFromTarget;
		if (distance <= 2) {
			textDisplay.GetComponent<Text> ().text = "Take pistol [Press E]";
			if (Input.GetButtonDown ("Action")) 
				takePistol ();
		}
	}

	void OnMouseExit() {
		textDisplay.GetComponent<Text> ().text = "";
	}

	void takePistol() {
		AudioSource pickupSound = GetComponent<AudioSource> ();

		weaponController.transform.SendMessage ("addPistol");

		pickupSound.Play ();
		fakeGun.SetActive (false);
		ammoDisplay.SetActive (true);

		Debug.Log ("Picked up Pistol");
	}
}
