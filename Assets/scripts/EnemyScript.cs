using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public int enemyHealth = 100;

	public GameObject zombie;

	void takeDamage(int damage) {
		enemyHealth -= damage;
		Debug.Log ("Lost health: " + damage);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) {
			this.GetComponent<ZombieFollow> ().enabled = false;
			zombie.GetComponent<Animation> ().Play ("Dying");
			StartCoroutine (endZombie());
		}
	}

	IEnumerator endZombie() {
		yield return new WaitForSeconds (3f);
		Destroy (gameObject);
	}
}
