using UnityEngine;
using System.Collections;

public class SwitchTo3D : MonoBehaviour {

	public Camera cam;
	public GameObject level;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Camera.main.orthographic = false;
		}
	}
}
