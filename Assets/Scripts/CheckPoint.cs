using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	private float rotation = 100;
	private float moveSpeed = 0.02f;
	private Vector3 startPosition;
	private bool stateGoUp = true;

	void Start() {
		startPosition = transform.position;
	}

	void Update() {
		transform.Rotate(0, rotation * Time.deltaTime, 0);

		if (stateGoUp && transform.position.y < startPosition.y + 0.9)
			transform.position += new Vector3(0 , moveSpeed, 0);
		else if (!stateGoUp && transform.position.y > startPosition.y)
			transform.position -= new Vector3(0 , moveSpeed, 0);
		else
			stateGoUp = !stateGoUp;

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerController>().setRespawnPos(transform.position);
			other.gameObject.GetComponent<PlayerController>().setCurrentCheckpoint(gameObject);
		}
	}
}
