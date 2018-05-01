using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupSmg : MonoBehaviour {

	private float distance = PlayerCasting.distanceFromTarget;
	public GameObject textDisplay;

	public GameObject fakeGun;
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
			textDisplay.GetComponent<Text> ().text = "Take SMG [Press E]";
			if (Input.GetButtonDown ("Action")) 
				takeSmg ();
		}
	}

	void OnMouseExit() {
		textDisplay.GetComponent<Text> ().text = "";
	}

	void takeSmg() {
		AudioSource pickupSound = GetComponent<AudioSource> ();

		weaponController.transform.SendMessage ("addSmg");

		pickupSound.Play ();
		fakeGun.SetActive (false);

		Debug.Log ("Picked up SMG");

	}
}
