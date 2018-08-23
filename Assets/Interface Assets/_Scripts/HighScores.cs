using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * 
 * File: 			HighScores.cs
 * Author: 			Philip Ong
 * Description: 	Works with the score that the player gets upon death, will create a score if none exists, will sort the scores from highest score to lowest and will create/instantiate the scores as an object onto the highscores window
 * 
 */

public class HighScores : MonoBehaviour {

	public GameObject scoreBar; //the prefab which the score is shown on, each score has its own scoreBar gameobject
	public Transform scoreBarParent; //gets the "Spacer" gameobject to grab its transform;


	void Start () {
		CheckPrefs ();
		CreateScoreBar ();
		}	

	void CheckPrefs(){
		//Checks if player already has playerprefs (only 10 players prefs are ever stored for a top 10 list)
		for (int i = 0; i < 10; i++)
		{
			if (PlayerPrefs.HasKey ("playerScore" + i)) //only the score is checked if it exists since a name will always go with a score.
			{
				return;
			} 
			else //if there is no players prefs, then default ones will be created in its place
			{
				PlayerPrefs.SetFloat ("playerScore" + i, 0f);
				PlayerPrefs.SetString ("playerName" + i, "Nobody");
			}
		}
		//end check
	}

	//functions for creating gameobjects (rows) in which the players name and score are shown on
	void CreateScoreBar(){
		for (int i = 0; i < 10; i++) {//creates 10 rows for a top 10 list
			GameObject newScoreBar = Instantiate (scoreBar) as GameObject;//creates a prefab of the scorebar for ever loop of the for loop
			newScoreBar.transform.SetParent (scoreBarParent.transform, false);//changes its transform to be a child of another object (for verticle layout purposes)
			Text newNameText = newScoreBar.transform.Find ("NameText").gameObject.GetComponent<Text> ();//grabs the Text object for player name
			newNameText.text = PlayerPrefs.GetString ("playerName" + i);//displays stored player name
			Text newScoreText = newScoreBar.transform.Find ("ScoreText").gameObject.GetComponent<Text> ();//finds the text object for score
			newScoreText.text = PlayerPrefs.GetFloat ("playerScore" + i).ToString ("0");//displays the stored player score as a string with 0 decimals (whole number)
		}
	}
}