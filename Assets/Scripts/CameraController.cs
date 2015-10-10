using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	
	public Vector3 startingOffset;
	private Vector3 offset;
    private float yRotation = 0;

	private float cameraRotationSpeed = 7;
	private float cameraMoveSpeed = 50;
	private Quaternion targetPos = Quaternion.Euler(0,0,0);

	// Use this for initialization
	void Start () {
		offset = startingOffset;
		transform.position = player.transform.position + offset;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position + offset, Time.deltaTime*cameraMoveSpeed);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetPos, Time.deltaTime*cameraRotationSpeed);
	}
	
	public void rotateCamera(float degrees) {
        yRotation = (yRotation + degrees) % 360;
		targetPos = Quaternion.Euler (transform.rotation.x, yRotation, transform.rotation.y);
        offset = new Vector3(startingOffset.z*Mathf.Sin(yRotation*Mathf.PI/180), offset.y, startingOffset.z*Mathf.Cos(yRotation * Mathf.PI/180));
	}
}
