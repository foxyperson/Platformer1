using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

    public string Destination;

    public void loadScene () {
        Application.LoadLevel (Destination);
    }
}
