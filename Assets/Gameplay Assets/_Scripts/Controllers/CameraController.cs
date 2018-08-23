using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* --------------------------------------------------------------------------------------------------------------------------------------------------------- //
   Author: 			Hayden Reeve
   File:			CameraController.cs
   Description: 	This script controls the camera's position in relation to the player objects. This script must be applied to the camera object.
// --------------------------------------------------------------------------------------------------------------------------------------------------------- */

public class CameraController : MonoBehaviour {


	// Inspector Variables

	[Header("PLayer Objects")]

	[Tooltip("Link this to one of the player objects.")]
	[SerializeField] public Transform _trFoxOne;

	[Tooltip("Link this to the other player object.")]
	[SerializeField] public Transform _trFoxTwo;


	// Hidden Variables

	[HideInInspector] Transform _trCamera;


	// Use this for initialization
	void Start () {

		_trFoxOne = _trFoxOne.GetComponent<Transform> ();
		_trFoxTwo = _trFoxTwo.GetComponent<Transform> ();
		_trCamera = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (_trFoxOne != null && _trFoxTwo != null) {
			_trCamera.position = new Vector3 ((_trFoxOne.position.x + _trFoxTwo.position.x) / 2f, _trCamera.position.y, _trCamera.position.z);
		}
	}
}
