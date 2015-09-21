using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	public Vector3 offset;

	private Vector2 playerRelativeToEdge;

	public float cameraLowestY;
	private float offsetCameraLowestY;
	public float cameraLowestX;
	private float offsetCameraLowestX;

	// Use this for initialization
	void Start () {
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
		/*transform.position = new Vector3(
			-(Input.mousePosition.x-1000)/10,
			-(Input.mousePosition.y-400)/10,
			-15);
		print (transform.position);*/
	}
}
