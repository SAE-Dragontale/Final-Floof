using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerrySound : MonoBehaviour {
    public AudioSource soundFX;
    // Use this for initialization
    void Start () {
        AudioSource soundFX = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {
            soundFX.Play();
        }
    }
}
