using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerFacer : MonoBehaviour {
    private Transform Player;
    private TextMeshProUGUI InformationText;


    // Use this for initialization
    void Start () {
        Player = FindObjectOfType<PlayerController>().transform;
        InformationText = GetComponentInChildren<TextMeshProUGUI>();
        InformationText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        InformationText.gameObject.transform.LookAt(Player);
        InformationText.gameObject.transform.Rotate(0, 180, 0);
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Player")) {
            InformationText.enabled = true;

        }
    }


    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
            InformationText.enabled = false;
    }

}
