using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float moveX;
	public float moveVelocity;

	private float jump;
	public float jumpVelocity;

	private bool grounded;
	private bool hasDoubleJumped = false;

	public int deathDepth;
	public Vector3 respawnPos;
	int jumpCounter = 0;


	// Use this for initialization
	/*void Start () {
	
	}*/
	
	// Update is called once per frame
	void Update () {	
		// Jump
		

		if (grounded) {
			hasDoubleJumped = false;
			if (Input.GetKey(KeyCode.Space))
				jump = jumpVelocity;
			else
				jump = 0;
		} else {
			if (Input.GetKeyDown(KeyCode.Space) && !(hasDoubleJumped)){
				jump = jumpVelocity;
				hasDoubleJumped = true;
			}
			else
				jump = GetComponent<Rigidbody>().velocity.y;
		}

		// Movement
		moveX = Input.GetAxis("Horizontal") * moveVelocity;

		GetComponent<Rigidbody>().velocity = new Vector3(moveX, jump, 0);

		// Death
		if (this.transform.position.y < deathDepth) {
			this.transform.position = respawnPos;
		}
	
	}
	// Grounded
	void OnTriggerEnter() {
		grounded = true;
	}
	void OnTriggerExit() {
		grounded = false;
	}
}
