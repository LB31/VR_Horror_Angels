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

    private bool AngelFound;

    private void Start() {
        goal = FindObjectOfType<PlayerController>().transform;
        agent = GetComponent<NavMeshAgent>();

       
        OwnRenderer = BeenSeenPlacebo.GetComponent<Renderer>();
        AllRenderers = AngelModels.GetComponentsInChildren<Renderer>();

    }
    void Update() {
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
    }

    void ChangeAngelVisibility(bool toAttack, bool hideAll) {
        if(toAttack) {
            // 0 is idle
            AngelModels.transform.GetChild(0).gameObject.SetActive(!toAttack);
            // 1 is attacking
            AngelModels.transform.GetChild(1).gameObject.SetActive(toAttack);
        } else {
            // 0 is idle
            AngelModels.transform.GetChild(0).gameObject.SetActive(!toAttack);
            // 1 is attacking
            AngelModels.transform.GetChild(1).gameObject.SetActive(toAttack);
        }
        if (hideAll) {
            AngelModels.transform.GetChild(0).gameObject.SetActive(false);
            AngelModels.transform.GetChild(1).gameObject.SetActive(false);
        }
    }


}
