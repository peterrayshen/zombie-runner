using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour {

	public GameObject gunLabel;

	public static string currentWeapon;

	public static int loaded_ammo_pistol;
	public GameObject loaded_display;

	public static int total_ammo_pistol;
	public GameObject ammo_display;

	public int start_ammo_pistol;
	public int clip_size_pistol;

	public static int loaded_ammo_smg;
	public GameObject loaded_display_smg;

	public static int total_ammo_smg;
	public GameObject ammo_display_smg;

	public int start_ammo_smg;
	public int clip_size_smg;

	// Use this for initialization
	void Start () {
		total_ammo_pistol = start_ammo_pistol;
		loaded_ammo_pistol = clip_size_pistol;

		total_ammo_smg = start_ammo_smg;
		loaded_ammo_smg = clip_size_smg;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentWeapon == "pistol") {
			ammo_display.GetComponent<Text> ().text = "" + total_ammo_pistol;
			loaded_display.GetComponent<Text> ().text = "" + loaded_ammo_pistol;
			gunLabel.GetComponent<Text> ().text = "9MM";
		} else if (currentWeapon == "smg") {
			ammo_display.GetComponent<Text> ().text = "" + total_ammo_smg;
			loaded_display.GetComponent<Text> ().text = "" + loaded_ammo_smg;
			gunLabel.GetComponent<Text> ().text = "MP5K";
		} else {
			ammo_display.GetComponent<Text> ().text = "";
			loaded_display.GetComponent<Text> ().text = "";
			gunLabel.GetComponent<Text> ().text = "";
		}
	}
}
