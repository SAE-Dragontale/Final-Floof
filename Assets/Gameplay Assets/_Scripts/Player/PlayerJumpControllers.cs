using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpControllers : MonoBehaviour {

	// ----

	[Header("Player Objects")]
	public FoxController _fxFoxBackground;
	public FoxController _fxFoxForeground;

	// ----

/// <summary>
/// Author: Matt Donnelly
/// Date:9/06/2017
/// JumpController.cs
/// This script is used for the touch controls for two characters also includes an drag fuction to pause and return to game play
/// Edit by Hayden Reeve: Hooked this script and the FoxController script..
/// </summary>
    private Vector3 firstTouchPosition;// vector for first touch
    private Vector3 lastTouchPosition;// vector for last touch

    private float dragDistances;// drag distances float

    public GameObject Canvas;// Canvas 
    public GameObject GameOver;

    

    public AudioSource source_fxFoxBackground;
    public AudioSource source_fxFoxForeground;

    

   
    void Start()
    {

		_fxFoxBackground = _fxFoxBackground.GetComponent<FoxController> ();
		_fxFoxForeground = _fxFoxForeground.GetComponent<FoxController> ();


        dragDistances = Screen.height * 20 / 100; // dragDistance is 20% heigh of the screen

        Canvas.SetActive(false);
        GameOver.SetActive(false);

        AudioSource source_fxFoxBackground = GetComponent<AudioSource>();
        AudioSource source_fxFoxForeground = GetComponent<AudioSource>();


    }





    void Update()
    {

        if (Input.touchCount == 1)
        {
            Touch ft = Input.GetTouch(0);

            if (ft.phase == TouchPhase.Began)
            {
                firstTouchPosition = ft.position;
                lastTouchPosition = ft.position;

                if (ft.position.x > Screen.width * 0.5)
                {
                    InputRightSide();
                }

                else if (ft.position.x < Screen.width * 0.5)
                {
                    InputLeftSide();
                }
            }


        }
    }

    void InputRightSide()
    {
		_fxFoxBackground._willJump = true;
        source_fxFoxBackground.Play();
        
    }

    void InputLeftSide()
    {
		_fxFoxForeground._willJump = true;
        source_fxFoxForeground.Play();
        
    }
}
    
    
    


