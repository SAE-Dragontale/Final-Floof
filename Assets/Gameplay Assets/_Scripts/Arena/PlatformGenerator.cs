using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	// genertaes platforms
	public Transform generationPoint;
	public float distanceBetween;
	// finds width between platforms

	private float platformWidth;
	// stops overlapping.

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	public ObjectPool[] theObjectPools;

	//public GameObject[] thePlatforms;
	private int platfromSelector;
	private float[] platformWidths;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;


	// Use this for initialization
	void Start () {
	
		//platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;
		// finds how wide the platform is.

		platformWidths = new float[theObjectPools.Length];

		for ( int i = 0; i < theObjectPools.Length; i++)
		{
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider> ().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x) 
		{

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			platfromSelector = Random.Range (0, theObjectPools.Length);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (heightChange < minHeight) {
				heightChange = minHeight;
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platfromSelector] / 2) + distanceBetween, heightChange, transform.position.z);
			//creates platfroms where platform generator is. checks



			//Instantiate (/*thePlatform */ theObjectPools[platfromSelector], transform.position, transform.rotation);

			GameObject newPlatform = theObjectPools[platfromSelector].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true); 


			transform.position = new Vector3 (transform.position.x + (platformWidths[platfromSelector] / 2), transform.position.y, transform.position.z);
			// add on from position platfrom was

		}
	
	
	}
}
