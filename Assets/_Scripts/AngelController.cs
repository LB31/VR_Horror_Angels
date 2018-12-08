using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngelController : MonoBehaviour {
    public GameObject BeenSeenPlacebo;
    public GameObject AngelModels;

    public Renderer[] AllRenderers;
    public Renderer OwnRenderer;

    // Path finding
    public Transform goal;
    private NavMeshAgent agent;

    public bool AngelFound;

    private bool CrashedPlayer;
    private float t;

    private void Start() {
        goal = FindObjectOfType<PlayerController>().transform;
        agent = GetComponent<NavMeshAgent>();

       
        OwnRenderer = BeenSeenPlacebo.GetComponent<Renderer>();
        AllRenderers = AngelModels.GetComponentsInChildren<Renderer>();

    }
    void Update() {
        if (!CrashedPlayer) {
            float distance = Vector3.Distance(Camera.main.transform.position, transform.position);
            bool modelAttacks = (distance > 2.5) ? false : true;

            // IsVisibleFrom is a method from the RendererExtensions.cs script
            if (OwnRenderer.IsVisibleFrom(Camera.main)) {
                if (!AngelFound) {
                    ChangeAngelVisibility(modelAttacks, false);
                    AngelFound = true;
                }
                agent.enabled = false;
            } else {
                AngelFound = false;
                ChangeAngelVisibility(modelAttacks, true);
                agent.enabled = true;
                agent.destination = goal.position;

            }
        } else {
            t += Time.deltaTime;
        }
        if (t > 5) {
            t = 0;
            CrashedPlayer = false;
        }


            
    }

    void ChangeAngelVisibility(bool toAttack, bool hideAll) {
        if (hideAll) {
            AngelModels.transform.GetChild(0).gameObject.SetActive(false);
            AngelModels.transform.GetChild(1).gameObject.SetActive(false);
        } else {
            // 0 is idle
            AngelModels.transform.GetChild(0).gameObject.SetActive(!toAttack);
            // 1 is attacking
            AngelModels.transform.GetChild(1).gameObject.SetActive(toAttack);
        }
    }

    // Tracks, if angel have attacked player to stop him for some seconds
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") && !AngelFound) {

            CrashedPlayer = true;
            agent.enabled = false;
            ChangeAngelVisibility(true, false);
            AngelFound = true;
        }
    }


}
