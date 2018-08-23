using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Author: Matt Donnelly
/// Co-Author: Philip Ong
/// Date: 9/06/2017
/// ReturnToGamePlay.cs
/// This script pauses the game as well as previding functions for buttons
/// Philip Ong: added functions for HighScoreApply(), and AddScore()
/// </summary>

public class ReturnToGamePlay : MonoBehaviour
{
    public GameObject Canvas;
	public GameObject InputCanvas;
	public InputField nameInput;


    public void ReturnPlay()
    {
        Canvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitPlay()
    {
        Application.Quit();
    }

	public void Restart()
	{
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
		Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

	//on "Apply" button press, calls this function to store the name typed in the Inputfield to be called in the highscores window (mainmenu scene)
	public void HighScoreApply()
	{
		string highscoreString = nameInput.text; //stores the text in Inputfield
//		Debug.Log (highscoreString);
		AddScore (highscoreString, Time.timeSinceLevelLoad); //calls the function AddScore and passes through the name of the player (highscoreString) and players score (in this case we used the time since the level loaded as the score)
		InputCanvas.SetActive (false);//once button is pressed the inputfield and Apply button will hide so that the player can not click Apply multiple times and tehrefore added multiple scores
	}

	void AddScore(string name, float score){
		float newScore;
		string newName;
		float oldScore;
		string oldName;
		newScore = score;
		newName = name;

		for (int i = 0; i < 10; i++) {
			if (PlayerPrefs.GetFloat ("playerScore" + i) < newScore) {
				oldScore = PlayerPrefs.GetFloat ("playerScore" + i);
				oldName = PlayerPrefs.GetString ("playerName" + i);
				PlayerPrefs.SetFloat ("playerScore" + i, newScore);
				PlayerPrefs.SetString ("playerName" + i, newName);
				newScore = oldScore;
				newName = oldName;
			}
		}
	}
}
