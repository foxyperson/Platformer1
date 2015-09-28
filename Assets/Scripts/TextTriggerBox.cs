using UnityEngine;
using System.Collections;

public class TextTriggerBox : MonoBehaviour {

    public GameObject oldInfoText;
    public GameObject newInfoText;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (oldInfoText != null)
                Destroy(oldInfoText);
            if (newInfoText != null)
                newInfoText.SetActive(true);
        }
    }
}