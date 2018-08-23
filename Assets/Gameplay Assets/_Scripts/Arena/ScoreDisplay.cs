using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * 
 * File: 			ScoreDisplay.cs
 * Author: 			Philip Ong
 * Description: 	Simple script for the display of the score during gameplay
 * 
 */

public class ScoreDisplay : MonoBehaviour {
	public Text scoreText;

	void Update () {
		scoreText.text = "Score: " + Time.timeSinceLevelLoad.ToString("0");
	}
}
