using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	
	public Vector3 startingOffset;
	private Vector3 offset;
    private float yRotation = 0;

	private Vector2 playerRelativeToEdge;

	public float cameraLowestY;
	private float offsetCameraLowestY;
	public float cameraLowestX;
	private float offsetCameraLowestX;

	// Use this for initialization
	void Start () {
		offset = startingOffset;
		transform.position = player.transform.position + offset;

		Camera cam = Camera.main;
		offsetCameraLowestY = cameraLowestY + cam.orthographicSize;
		offsetCameraLowestX = cameraLowestX + cam.orthographicSize * cam.aspect;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
		if (transform.position.y <= offsetCameraLowestY) {
			transform.position = new Vector3(transform.position.x, offsetCameraLowestY, transform.position.z);
		} 
		if (transform.position.x <= offsetCameraLowestX) {
			transform.position = new Vector3(offsetCameraLowestX, transform.position.y, transform.position.z);
		} 
	}
	
	public void rotateCamera(float degrees) {
        transform.Rotate(0, degrees, 0);
        yRotation = (yRotation + degrees) % 360;
        offset = new Vector3(startingOffset.z * Mathf.Sin(yRotation * Mathf.PI/180), 0, startingOffset.z * Mathf.Cos(yRotation * Mathf.PI/180));
	}
}
