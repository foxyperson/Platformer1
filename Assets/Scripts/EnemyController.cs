using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public float moveVelocity;
	private float moveX;
	private float moveZ;
	public float maxAggroRange;
	public float minAggroRange;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		float xDiff = playerPos.x - transform.position.x;
		float yDiff = playerPos.y - transform.position.y;
		float zDiff = playerPos.z - transform.position.z;

		moveX = 0;
		moveZ = 0;
		if (maxAggroRange > Mathf.Abs (xDiff) && 
		    maxAggroRange > Mathf.Abs (yDiff) && 
		    maxAggroRange > Mathf.Abs (zDiff)) { // in aggrorange on both axis
			if (minAggroRange < xDiff) // in aggrorange on posetive x-axis
				moveX = moveVelocity;
			else if (xDiff < -minAggroRange) // in aggrorange on negative x-axis
				moveX = -moveVelocity;

			if (minAggroRange < zDiff) // in aggrorange on posetive z-axis
				moveZ = moveVelocity;
			else if (zDiff < -minAggroRange)  // in aggrorange on negative z-axis
				moveZ = -moveVelocity;
		}

		GetComponent<Rigidbody>().velocity = new Vector3(moveX, GetComponent<Rigidbody>().velocity.y, moveZ);
	}
}
