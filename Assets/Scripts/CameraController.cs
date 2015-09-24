using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	
	public Vector3 startingOffset;
	private Vector3 offset;

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
	
	public void rotateCamera(float x, float y, float z) {
		transform.Rotate (x, y, z);
		offset += new Vector3(startingOffset.y * Mathf.Sin(y*Mathf.PI/180), 0, startingOffset.y * Mathf.Cos(y*Mathf.PI/180));
		float newX = ((offset.x + startingOffset.y - 1) % (startingOffset.y * 2)) + 1;
		print(newX);
		/*offset = new Vector3(((offset.x + startingOffset.y - 1) % (startingOffset.y*2)) + 1, 
		                     ((offset.y + startingOffset.y - 1) % (startingOffset.y*2)) + 1, 
		                     ((offset.z + startingOffset.y - 1) % (startingOffset.y*2)) + 1);*/
		//print (offset);
	}
}
