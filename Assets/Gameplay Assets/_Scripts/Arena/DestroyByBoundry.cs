using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* --------------------------------------------------------------------------------------------------------------------------------------------------------- //
	Author: 		Hayden Reeve
	Co-Author:		Philip Ong
	File:			DestroyByBoundry.cs
	Description: 	This script destroys objects colliding with it (Meaning the area is kept sanitary from memory leaks) as well as monitor's the player's state.

	Philip Edit:	Added code to calculate if the players score has made it into the top 10, if it has the Inputfield for the player to input their name will appear
// --------------------------------------------------------------------------------------------------------------------------------------------------------- */

public class DestroyByBoundry : MonoBehaviour {

	public GameObject InputCanvas;

    public AudioSource deathSound;

	void OnTriggerExit(Collider cl)
	{

		// When the character falls off the screen, we need to tell everyone that the game is over and it's time to go home.
		if (cl.gameObject.tag == "Player") {

			// Aquire the FoxController's "Game Over" script.
			GameObject gmGameOver = cl.GetComponent<FoxController> ()._gmGameOver;

			// Pause the time scale. We don't want our score incrementing further once the game has ended.
			Time.timeScale = 0f;

			// Activate the Game Over Menu 
			gmGameOver.SetActive (true);

            //If player triggers Boundry play death sound
            deathSound.Play();

			//Cycles through all the stored player scores (top 10 scores) and checks it against the player current score
			for (int i = 0; i < 10; i++) {
				if (PlayerPrefs.GetFloat ("playerScore" + i) < Time.timeSinceLevelLoad)//if it is in the top 10 then show the Inputfield
				{
					Debug.Log (i + "place");
					InputCanvas.SetActive (true);
				} 
//				else 
//				{
//					Debug.Log (i);
//				}
			}
		}

		// Destroy the collision
		Destroy(cl.gameObject);
	}
}
