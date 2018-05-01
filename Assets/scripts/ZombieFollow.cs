using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollow : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;

	private float targetDistance;
	public float allowedRange;

	public float enemySpeed;
	public int attackTrigger = 0;

	public RaycastHit hit;

	public bool isAttacking;
	public GameObject screenFlash;

	public AudioSource hurt1, hurt2, hurt3;
	private int painSound;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out hit)) {
			targetDistance = hit.distance;
			if (targetDistance < allowedRange) {
				if (attackTrigger == 0) {
					enemy.GetComponent<Animation> ().Play ("Walking");
				} else if (attackTrigger == 1) {
					if (!isAttacking) {
						StartCoroutine (enemyDamage ());
					}
					enemy.GetComponent<Animation> ().Play ("Attacking");
				}
			} else {
				enemy.GetComponent<Animation> ().Play ("Idle");
			}
		}
	}

	void OnTriggerEnter() {
		Debug.Log ("Trigger Enter");
		attackTrigger = 1;
	}

	void OnTriggerExit() {
		Debug.Log ("Trigger Exit");
		attackTrigger = 0;
	}

	IEnumerator enemyDamage() {
		isAttacking = true;
		painSound = Random.Range (1, 4);
		yield return new WaitForSeconds (0.9f);
		screenFlash.SetActive (true);
		GlobalHealth.playerHealth -= Random.Range (5, 16);

		if (painSound == 1)
			hurt1.Play ();
		else if (painSound == 2)
			hurt2.Play ();
		else
			hurt3.Play ();

		yield return new WaitForSeconds (0.05f);
		screenFlash.SetActive (false);
		yield return new WaitForSeconds (1);
		isAttacking = false;
	}
}
