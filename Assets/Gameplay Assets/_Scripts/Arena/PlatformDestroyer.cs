using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject platformDesctructionPoint;


	// Use this for initialization
	void Start () {
		platformDesctructionPoint = GameObject.Find ("PlatformDestructionPoint");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < platformDesctructionPoint.transform.position.x) 
		
		{
			//Destroy (gameObject);

			gameObject.SetActive (false);
		}
	
	}
}
