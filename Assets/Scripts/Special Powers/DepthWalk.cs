using UnityEngine;
using System.Collections;

public class DepthWalk : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerController>().setDepthWalk(true);
            Destroy (gameObject);
		}
	}
}