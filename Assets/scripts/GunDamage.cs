using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDamage : MonoBehaviour {

	public int damage = 5;
	public float targetDistance;
	public float allowedRange = 15;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalAmmo.loaded_ammo_pistol > 0) {
			if (Input.GetButtonDown ("Fire1")) {
				RaycastHit shot = new RaycastHit();
				if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot)) 
					shot.transform.SendMessage("takeDamage", damage);
			}
		}
	}
}
