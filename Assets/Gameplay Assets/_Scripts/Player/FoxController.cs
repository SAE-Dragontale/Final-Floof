using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* --------------------------------------------------------------------------------------------------------------------------------------------------------- //
   Author: 			Hayden Reeve
   File:			FoxController.cs
   Description: 	This script defines the player objects behaviour in regards to their environments. This script must be applied to each player object.
// --------------------------------------------------------------------------------------------------------------------------------------------------------- */

[RequireComponent(typeof(Rigidbody))]
public class FoxController : MonoBehaviour {


	// ---- Inspector Variables

	[Header("Player Settings")]

	[Tooltip("The force applied when the character jumps. Remember to adjust this when you adjust the character's mass!")]
	[SerializeField] public float _flJumpForce = 250f;

	[Tooltip("The force applied to the player's object when they are touching a Berry Bush (Relative).")]
	[SerializeField] public float _flObjectSpeeder = 3f;

	[Tooltip("The force applied to the player's object when they are touching Long Grass (Relative).")]
	[SerializeField] public float _flObjectSlower = -3f;

	[Header("Arena Settings")]

	[Tooltip("Set this string to the 'Tag' attached to the platform objects.")]
	[SerializeField] public string _stArenaTag = "Arena";

	[Tooltip("Set this string to the 'Tag' attached to the Berry Bushes (Speed Up!).")]
	[SerializeField] public string _stBerriesTag = "Berries";

	[Tooltip("Set this string to the 'Tag' attached to the Long Grass (Slow Down!).")]
	[SerializeField] public string _stLongGrassTag = "Grass";

	[Tooltip("Whether the fox is on the front layer of the arena (True), or the back layer of the arena (False)")]
	[SerializeField] public bool _isForeground = true;


	[Header("UI Settings")]

	[Tooltip("Set this gameobject to the GameOver Menu.")]
	[SerializeField] public GameObject _gmGameOver;


	[Header("Debug Settings")]

	[Tooltip("Whether the character should move or not. This should be disabled by default.")]
	[SerializeField] public bool _isMoving = false;

	[Tooltip("The force applied to the player's forward momentum. This is for developer purposes only, and should normally have no impact on the game.")]
	[SerializeField] public float _flMovementSpeed = 5f;


	// ---- Hidden Variables

	// Personal Variables.
	private Rigidbody _rb;
	private Collider _cd;
	private Animator _an;

	// Jumping Variables
	[HideInInspector] public bool _willJump = false; // This Variables MUST be Public. It is accessed by other controller scripts to enable the player to jump with touch controls.

	private bool _isJumping = true;
	private bool _canLand = true;

	// Object Variables

	private bool _isSpeeding = false;
	private bool _isSlowing = false;


	// ---- Awake
	void Awake () {

		// Make sure time is running correctly on initialisation.
		Time.timeScale = 1f;

	}

	// ---- Initialization
	void Start () {

		_rb = GetComponent<Rigidbody> ();
		_cd = GetComponent<Collider> ();
		_an = GetComponentInChildren<Animator> ();

	}

	// ---- Update is called once per frame
	void Update () {

		// Execute a developer jump command depending on which z-axis line that the object is set to.
		if (_isForeground) {

			if (Input.GetKeyDown (KeyCode.A) && !_isJumping) {
				_willJump = true;
			}

		} else { 
			
			if (Input.GetKeyDown (KeyCode.D) && !_isJumping) {
				_willJump = true;
			}
		}

	}

	// ---- Called by the user pressing the on-screen buttons.
	void FixedUpdate () {

		Vector3 v3LookPos;
		float flLookAngle;

		// Check if we the player has been queued a jump by something. If it is, execute a vertical impulse.
		if (_willJump == true && !_isJumping) {
			_rb.AddForce (new Vector3(0f,_flJumpForce,0f),ForceMode.Impulse);
			StartCoroutine (JumpDelay());
		}

		// Add a constant velocity forwards if the DEV COMMAND is turned on. This should be disabled by default.
		if (_isMoving) {
			_rb.AddForce (new Vector3 (_flMovementSpeed, 0f, 0f), ForceMode.Acceleration);
		}

		// If we are in contact with Berries...
		if (_isSpeeding) {
			_rb.AddForce (new Vector3 (_flObjectSpeeder, 0f, 0f), ForceMode.Acceleration);
		}

		// If we are in contact with Long Grass...
		if (_isSlowing) {
			_rb.AddForce (new Vector3 (_flObjectSlower, 0f, 0f), ForceMode.Acceleration);
		}
			
		// Change the rotation of the object based on the current vertical velocity of the object. While it's going up, angle it upwards, vice versa.
		if (_isJumping) {
			
			v3LookPos = new Vector3 (_rb.velocity.x, _rb.velocity.y -5f, _rb.velocity.z);
			flLookAngle = Mathf.Atan2 (v3LookPos.y, v3LookPos.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.AngleAxis ( flLookAngle, Vector3.forward), Time.deltaTime * 0.25f);

		} else {
			
			transform.rotation = Quaternion.AngleAxis (0f, Vector3.forward);

		}


	}

	// Wait a small delay before allowing the player to jump again. This is useful to make sure that the player can't jump twice in the same frame.
	IEnumerator JumpDelay() {

		// Cleanup variables
		_willJump = false;
		_isJumping = true;
		_canLand = false;

		// Set the Animtor to play the Jumping Animation.
		_an.SetBool ("_isJumpingAnim", true);

		// Wait a second before allowing the player to 'land', making sure that a jump has actually started before executing further jumping code.
		yield return new WaitForSeconds (0.5f);
		_canLand = true;

	}

	// When we enter the Terrain Collider, we should report that the character has stopped jumping.
	void OnCollisionStay (Collision cn) {
		
		if (cn.gameObject.tag == _stArenaTag && _canLand) {
			_isJumping = false;
			_an.SetBool ("_isJumpingAnim", false);
		}

	}

	// When we leave the Terrain Collider, we should report that the character has started jumping. This is useful in case the character falls off a platform rather than jumps off.
	void OnCollisionExit (Collision cn) {
		
		if (cn.gameObject.tag == _stArenaTag) {
			_isJumping = true;
			_an.SetBool ("_isJumpingAnim", true);
		}

	}

	// While we're in trigger-contact with an object we either need to go slower, or faster respectively.
	void OnTriggerStay (Collider cd) {
		
		if (cd.gameObject.tag == _stLongGrassTag) { 
			_isSlowing = true;
			_an.SetFloat ("_flAnimSpeed",0.5f);
		}

		if (cd.gameObject.tag == _stBerriesTag) {
			_isSpeeding = true;
			_an.SetFloat ("_flAnimSpeed",1.5f);
		}

	}

	// When we leave trigger contact with the object, we need to make sure the effects end.
	void OnTriggerExit (Collider cd) {

		if (cd.gameObject.tag == _stLongGrassTag) { 
			_isSlowing = false;
		}

		if (cd.gameObject.tag == _stBerriesTag) {
			_isSpeeding = false;
		}

		_an.SetFloat ("_flAnimSpeed",1f);

	}
		
}
