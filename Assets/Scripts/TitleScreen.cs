using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

    private float moveSpeed = 0.08f;
    private Vector3 startPosition;
    private int direction = 0;
    private int moveX  = 16;
    private int moveY = 7;

    void Start() {
        startPosition = transform.position;
    }

    void Update() {
        if (direction == 0 && transform.position.x < startPosition.x + moveX)
            transform.position += new Vector3(moveSpeed, 0, 0);
        else if (direction == 1 && transform.position.y < startPosition.y + moveY)
            transform.position += new Vector3(0, moveSpeed, 0);
        else if (direction == 2 && transform.position.x > startPosition.x)
            transform.position -= new Vector3(moveSpeed, 0, 0);
        else if (direction == 3 && transform.position.y > startPosition.y)
            transform.position -= new Vector3(0, moveSpeed, 0);
        else
            direction = (direction + 1) % 4;

    }

}
