using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* 
 * 
 * File: 			MenuSelector.cs
 * Author: 			Philip Ong
 * Description: 	Script to handle Menus and buttons aswell as the options for sound.
 * 
 */

public class MenuSelector: MonoBehaviour {

	public GameObject MainMenuWindow;
	public GameObject OptionsWindow;
	public GameObject HighScoresWindow;
	public Toggle musicToggle;
	int mainMusic;

	void Awake(){
		AudioCheck ();//checks before anything else if the players audio was set to mute last play session
	}

	void Start(){
		ButtonBackToMenu ();//makes sure the MainMenuWindow is active on boot
	}

	public void ButtonPlay(){
//		Debug.Log ("Enter Scene name in script");
		SceneManager.LoadScene ("Gameplay");//loads play scene
	}
		
	public void ButtonOptions(){
		MainMenuWindow.SetActive (false);
		OptionsWindow.SetActive (true);
	}

	public void ButtonBackToMenu(){
		//makes sure that MainMenu will be the only window active (this function/button is called more than once), if more menus/windows are added please make sure to disable in this start function.
		OptionsWindow.SetActive (false);
		HighScoresWindow.SetActive (false);
		MainMenuWindow.SetActive (true);
	}

	public void ButtonHighScore(){
		MainMenuWindow.SetActive (false);
		HighScoresWindow.SetActive (true);
	}

	public void ButtonExit(){//Quits the application
		Application.Quit();
	}

	public void AudioCheck(){//checks playerprefs to see if player had muted audio last play session, if so audio will still be muted
		if (PlayerPrefs.HasKey ("Music")) {
			mainMusic = PlayerPrefs.GetInt ("Music");
			if (mainMusic == 0) {
				musicToggle.isOn = false;
			} else {
				musicToggle.isOn = true;
			}
		}
	}

	public void MusicToggle(){//toggles master audio on or off depending on the toggle.
		if (musicToggle.isOn) 
		{
			PlayerPrefs.SetInt ("Music", 1);
			AudioListener.volume = 1f;
			Debug.Log ("Audio on");
		} 
		else 
		{
			PlayerPrefs.SetInt ("Music", 0);
			AudioListener.volume = 0f;
			Debug.Log ("Audio off");
		}
	}
}
