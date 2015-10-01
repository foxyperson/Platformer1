using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float moveX;
	private float moveZ;
	public float moveVelocity;

	private float jump;
	public float jumpVelocity;

	private bool grounded;
	private bool hasDoubleJumped = false;

	public int deathDepth;
	public Vector3 respawnPos;

	private bool hasDoubleJump = false;
	private bool hasDepthWalk = false;
	private bool hasControlCamera = false;

    private float rotationAmount = 90;
    private float currentRotation = 0;


	// Use this for initialization
	void Start () {
		respawnPos = transform.position; // for debugging purposes
	}

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
			if (Input.GetKeyDown(KeyCode.Space) && hasDoubleJump && !(hasDoubleJumped)){
				jump = jumpVelocity;
				hasDoubleJumped = true;
			}
			else
				jump = GetComponent<Rigidbody>().velocity.y;
		}

        if (currentRotation < 45)
            move("Horizontal", 1, "Vertical", 1);
        else if (currentRotation < 135)
            move("Vertical", 1, "Horizontal", -1);
        else if (currentRotation < 225)
            move("Horizontal", -1, "Vertical", -1);
        else
            move("Vertical", -1, "Horizontal", 1);

        GetComponent<Rigidbody>().velocity = new Vector3(moveX, jump, moveZ);
		// Camera control
		if (hasControlCamera) {
            if (Input.GetKeyDown("e")) {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().rotateCamera(rotationAmount);
                currentRotation = (currentRotation + rotationAmount) % 360;
            }
            if (Input.GetKeyDown("q")) {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().rotateCamera(-rotationAmount);
                currentRotation = ((currentRotation - rotationAmount) % 360 + 360) % 360;
            }
		}
		// Death
		if (transform.position.y < deathDepth)
			transform.position = respawnPos;
	}

    private void move (string xAxis, int xAxisInverter, string zAxis, int zAxisInverter) {
        moveX = xAxisInverter * Input.GetAxis(xAxis) * moveVelocity;
        if (hasDepthWalk)
            moveZ = zAxisInverter * Input.GetAxis(zAxis) * moveVelocity;
    }

	// Grounded
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag != "Special Power" && other.gameObject.tag != "Text Trigger")
			grounded = true;
	}
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag != "Special Power" && other.gameObject.tag != "Text Trigger")
			grounded = false;
	}

	public void setDoubleJump(bool b){
		hasDoubleJump = b;
	}

	public void setDepthWalk(bool b){
		hasDepthWalk = b;
	}

	public void setControlCamera(bool b){
		hasControlCamera = b;
	}
}
