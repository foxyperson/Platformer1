using UnityEngine;
using System.Collections;

public class DoubleJump : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerController>().setDoubleJump(true);
			Destroy (gameObject); // destroy itself
		}
	}
}