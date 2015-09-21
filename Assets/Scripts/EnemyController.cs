using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public float moveVelocity;
	private float moveX;
	private float moveZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		float xDiff = playerPos.x - transform.position.x;
		float zDiff = playerPos.z - transform.position.z;

		if (0.1 < xDiff && xDiff < 10)
			moveX = moveVelocity;
		else if (-10 < xDiff && xDiff < -0.1)
			moveX = -moveVelocity;
		else
			moveX = 0;

		if (0.1 < zDiff && zDiff < 10)
			moveZ = moveVelocity;
		else if (-10 < zDiff && zDiff < -0.1)
			moveZ = -moveVelocity;
		else
			moveZ = 0;

		GetComponent<Rigidbody>().velocity = new Vector3(moveX, GetComponent<Rigidbody>().velocity.y, moveZ);
	}
}
