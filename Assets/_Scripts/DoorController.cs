using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorController : MonoBehaviour {
    private GameObject InformationText;
    public GameObject TutorialAngel;

	void Awake () {
        InformationText = GetComponentInChildren<TextMeshProUGUI>().gameObject;
        InformationText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        InformationText.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        InformationText.SetActive(false);
    }

    public void OpenDoor() {
        GetComponent<Animator>().enabled = true;
        Destroy(InformationText);
        Destroy(TutorialAngel);
        GetComponent<BoxCollider>().enabled = false;
    }
}
