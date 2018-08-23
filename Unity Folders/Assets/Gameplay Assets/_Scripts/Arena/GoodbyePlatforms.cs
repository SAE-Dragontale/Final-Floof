using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodbyePlatforms : MonoBehaviour {

	public float AIspeed = 5;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (transform.position.x <= -20) {
			AIspeed = 5;
		}
		if (transform.position.x >= 8) {
			AIspeed = -5;
		}
		transform.Translate (AIspeed * Time.deltaTime, 0, 0);

	}
}
