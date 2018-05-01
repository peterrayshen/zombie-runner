using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData {
	public GameObject weapon_obj;
	public Animation animOut, animIn;
	public bool enabled;
	public string name;

	public WeaponData() {
		this.name = "not a weapon";
	}

	public WeaponData(GameObject weapon_obj, Animation animIn, Animation animOut, string name) {
		this.weapon_obj = weapon_obj;
		this.animIn = animIn;
		this.animOut = animOut;
		this.enabled = false;
		this.name = name;
	}

	public void enable() {
		this.enabled = true;
	}
}

public class WeaponController : MonoBehaviour {

	private ArrayList weapon_list;

	public GameObject crosshair;

	public GameObject pistol_obj;
	public GameObject smg_obj;

	public Animation pistol_anim_in, pistol_anim_out, smg_anim_in, smg_anim_out;

	private WeaponData pistol;
	private WeaponData smg;

	private WeaponData currentWeapon;

	// Use this for initialization
	void Start () {
		weapon_list = new ArrayList ();

		pistol_obj.SetActive (false);
		smg_obj.SetActive (false);

		pistol = new WeaponData (pistol_obj, pistol_anim_in, pistol_anim_out, "pistol");
		smg = new WeaponData (smg_obj, smg_anim_in, smg_anim_out, "smg");

		weapon_list.Add (pistol);
		weapon_list.Add (smg);

		currentWeapon = new WeaponData ();

		crosshair.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Switch")) {
			if (currentWeapon.name == "pistol" && smg.enabled == true) {
				currentWeapon.weapon_obj.SetActive (false);
				currentWeapon = smg;
				currentWeapon.weapon_obj.SetActive (true);
				GlobalAmmo.currentWeapon = "smg";
			}
			else if (currentWeapon.name == "smg" && pistol.enabled == true) {
				currentWeapon.weapon_obj.SetActive (false);
				currentWeapon = pistol;
				currentWeapon.weapon_obj.SetActive (true);
				GlobalAmmo.currentWeapon = "pistol";
			}
		} 
	}

	void addSmg() {
		crosshair.SetActive (true);
		for (int i = 0; i < weapon_list.Count; i++) {
			((WeaponData)weapon_list [i]).weapon_obj.SetActive (false);
		}
		for (int i = 0; i < weapon_list.Count; i++) {
			if (((WeaponData)weapon_list [i]).name == "smg") {
				currentWeapon = (WeaponData)weapon_list [i];
				((WeaponData)weapon_list [i]).weapon_obj.SetActive (true);
				((WeaponData)weapon_list [i]).enable ();
				GlobalAmmo.currentWeapon = "smg";
			}
		}
	}

	void addPistol() {
		crosshair.SetActive (true);
		for (int i = 0; i < weapon_list.Count; i++) {
			((WeaponData)weapon_list [i]).weapon_obj.SetActive (false);
		}
		for (int i = 0; i < weapon_list.Count; i++) {
			if (((WeaponData)weapon_list [i]).name == "pistol") {
				currentWeapon = (WeaponData)weapon_list [i];
				((WeaponData)weapon_list [i]).weapon_obj.SetActive (true);
				((WeaponData)weapon_list [i]).enable ();
				GlobalAmmo.currentWeapon = "pistol";
			}
		}
	} 
}


