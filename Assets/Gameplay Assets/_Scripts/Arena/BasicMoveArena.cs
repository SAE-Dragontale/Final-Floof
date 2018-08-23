using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveArena : MonoBehaviour {

	/* --------------------------------------------------------------------------------------------------------------------------------------------------------- //
   Author: 			Hayden Reeve
   File:			BasicMoveArena.cs
   Description: 	This script is a quick hack-job that simply moves the starting platform in the same fashion as the other platforms.
	// --------------------------------------------------------------------------------------------------------------------------------------------------------- */
	
	// Update is called once per frame
	void Update () {
		transform.position -= Vector3.right * (5f * Time.deltaTime);
	}
}
