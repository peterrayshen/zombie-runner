using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour {

	public float toTarget;
	public static float distanceFromTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0, 0, 1)), out hit)) {
			toTarget = hit.distance;
			distanceFromTarget = toTarget;
		}
	}
}
