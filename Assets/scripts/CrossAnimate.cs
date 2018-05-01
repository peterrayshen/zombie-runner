using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAnimate : MonoBehaviour {

	public GameObject up_curs;
	public GameObject down_curs;
	public GameObject right_curs;
	public GameObject left_curs;

	private float default_dist = 11f;

	// Use this for initialization
	void Start () {
		up_curs.transform.localPosition = new Vector3 (0, default_dist, 0);
		down_curs.transform.localPosition = new Vector3 (0, -default_dist, 0);
		right_curs.transform.localPosition = new Vector3 (default_dist, 0, 0);
		left_curs.transform.localPosition = new Vector3 (-default_dist, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		/* if (false) {
			up_curs.GetComponent <Animator>().enabled = true;
			down_curs.GetComponent <Animator>().enabled = true;
			right_curs.GetComponent <Animator>().enabled = true;
			left_curs.GetComponent <Animator>().enabled = true;
			StartCoroutine (waiting_anim());
		} */
	}

	IEnumerator waiting_anim() {
		yield return new WaitForSeconds (7f/60);
		up_curs.GetComponent <Animator>().enabled = false;
		down_curs.GetComponent <Animator>().enabled = false;
		right_curs.GetComponent <Animator>().enabled = false;
		left_curs.GetComponent <Animator>().enabled = false;
		set_default_pos ();
	}

	void set_default_pos() {
		up_curs.transform.localPosition = new Vector3 (0, default_dist, 0);
		down_curs.transform.localPosition = new Vector3 (0, -default_dist, 0);
		right_curs.transform.localPosition = new Vector3 (default_dist, 0, 0);
		left_curs.transform.localPosition = new Vector3 (-default_dist, 0, 0);
	}

}


