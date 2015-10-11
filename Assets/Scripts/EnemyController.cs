using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float moveVelocity;
	private Vector3 move;
	public float maxAggroRange;
	public float minAggroRange;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 diff = GameObject.FindGameObjectWithTag("Player").transform.position
									 - transform.position;

		move = new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);
		if (maxAggroRange > Mathf.Abs (diff.x) &&
		    maxAggroRange > Mathf.Abs (diff.y) &&
		    maxAggroRange > Mathf.Abs (diff.z)) { // in aggrorange on all axis
			if (minAggroRange < diff.x) // in aggrorange on posetive x-axis
				move.x = moveVelocity;
			else if (diff.x < -minAggroRange) // in aggrorange on negative x-axis
				move.x = -moveVelocity;

			if (minAggroRange < diff.z) // in aggrorange on posetive z-axis
				move.z= moveVelocity;
			else if (diff.z < -minAggroRange)  // in aggrorange on negative z-axis
				move.z = -moveVelocity;
		}

		move.y = GetComponent<Rigidbody>().velocity.y;

		GetComponent<Rigidbody>().velocity = move;
	}
}
