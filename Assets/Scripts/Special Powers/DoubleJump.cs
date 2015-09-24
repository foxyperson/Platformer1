using UnityEngine;
using System.Collections;

public class DoubleJump : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerController>().setDoubleJump(true);
			Destroy (gameObject);
		}
	}
}