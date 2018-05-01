using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour {

	public static int playerHealth = 100;
	private int internalHealth;

	public GameObject healthDisplay;

	// Use this for initialization
	void Start () {
		playerHealth = 100;
		internalHealth = playerHealth;
	}
	
	// Update is called once per frame
	void Update () {
		internalHealth = playerHealth;
		healthDisplay.GetComponent<Text> ().text = "Health: " + internalHealth;

		if (internalHealth <= 0) {
			SceneManager.LoadScene (2);
		}
	}
}
