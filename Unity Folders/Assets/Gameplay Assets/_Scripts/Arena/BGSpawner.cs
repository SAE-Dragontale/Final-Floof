using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

	public GameObject[] platforms;
	public Vector3 spawmValues;
	public float spawnWait;
	public float spawnMinWait;
	public float spawnMaxWait;
	public int startWait;
	public bool stop;

	int randPlatform;

	void Start () {
		StartCoroutine(PlatformCreator ());
	}


	void Update () {

		spawnWait = Random.Range (spawnMinWait, spawnMaxWait);
	}

	IEnumerator PlatformCreator ()
	{
		yield return new WaitForSeconds(startWait);

		while (!stop) 
		{
			randPlatform = Random.Range (0, 5);

			Vector3 spawnPosition = new Vector3 (Random.Range (-spawmValues.x, spawmValues.x), Random.Range (-spawmValues.y, spawmValues.y), 1);

			//	Vector3 spawnPosition = new Vector3 (Random.Range (-spawmValues.x, spawmValues.x),1, Random.Range (-spawmValues.z, spawmValues.z));

			Instantiate (platforms [randPlatform], spawnPosition + transform.TransformPoint (0,0,0), gameObject.transform.rotation);

			yield return new WaitForSeconds (spawnWait);
		}
	}
}
