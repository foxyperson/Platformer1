using UnityEngine;
using System.Collections;

public class SpecialPowers : MonoBehaviour {

    public enum specialPowers {
        ControlCamera,
        DepthWalk,
        DoubleJump
    }
    public specialPowers newEffect;

    private float rotation = 100;
    private float moveSpeed = 0.02f;
    private Vector3 startPosition;
    private bool stateGoUp = true;

    void start() {
        startPosition = transform.position;
    }

    void Update() {
        transform.Rotate(0, rotation * Time.deltaTime, 0);

        if (stateGoUp && transform.position.y < startPosition.y + 1)
            transform.position += new Vector3(0 , moveSpeed, 0);
        else if (!stateGoUp && transform.position.y > startPosition.y)
            transform.position -= new Vector3(0 , moveSpeed, 0);
        else
            stateGoUp = !stateGoUp;

    }


    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            switch(newEffect) {
                case specialPowers.ControlCamera:
                    other.gameObject.GetComponent<PlayerController>().setControlCamera(true);
                    break;
                case specialPowers.DepthWalk:
                    other.gameObject.GetComponent<PlayerController>().setDepthWalk(true);
                    break;
                case specialPowers.DoubleJump:
                    other.gameObject.GetComponent<PlayerController>().setDoubleJump(true);
                    break;
            }
            Destroy(gameObject); // destroy itself
        }
    }
}
