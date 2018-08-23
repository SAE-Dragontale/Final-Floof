using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpndown : MonoBehaviour {
	private Vector3 MovingDirection = Vector3.up;
	public float Uplimit = 3.0f;
	public float Downlimit = -3.0f;
	public float MovementSpeed = 2.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (MovingDirection * Time.smoothDeltaTime);

		if (gameObject.transform.position.y > Uplimit) {
			MovingDirection = Vector3.down;
		} else if (gameObject.transform.position.y < Downlimit) {
			MovingDirection = Vector3.up;
		}


	}
}
