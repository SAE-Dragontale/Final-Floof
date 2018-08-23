using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingMyPlatforms : MonoBehaviour {

	public GameObject thePlatform;
	private float platformWidth;

	public float scrollSpeed = 5.0f;
	public GameObject[] challenges;
	public float frequency = 1;
	float counter = 0.0f;
	public Transform challengesSpawnPoint;

	public float distanceBetween;
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	/*private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;*/

	// Use this for initialization
	void Start () {
		//platformWidth = thePlatform.GetComponent<BoxCollider> ().size.x;
		GenerateRandomChallenge ();

		//minHeight = transform.position.y;
		//maxHeight = maxHeightPoint.position.y;
	}

	// Update is called once per frame
	void Update () {

	//	distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);



		//generate objects
		if (counter <= 0.0f ){
			GenerateRandomChallenge();
		}else{
			counter -= Time.deltaTime * frequency;
		}
			

		//Scrolling
		GameObject currentChild;
		for (int i =0; i < transform.childCount; i++){
			currentChild = transform.GetChild (i).gameObject;
			ScrollChallenge (currentChild);
			/*if (currentChild.transform.position.x <= -15.0f) {
				Destroy (currentChild);
			}*/
		}


	}

	void GenerateRandomChallenge(){

	/*	heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

		if (heightChange > maxHeight) {
			heightChange = maxHeight;
		} else if (heightChange < minHeight) {
			heightChange = minHeight;
		}*/

		GameObject newChallenge = Instantiate (challenges [Random.Range (0, challenges.Length)], challengesSpawnPoint.position, Quaternion.identity) as GameObject;
		newChallenge.transform.parent = transform;
		counter = 1.0f;

	}


	void ScrollChallenge (GameObject currentChallenge)
	{
		currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);

	}
}
