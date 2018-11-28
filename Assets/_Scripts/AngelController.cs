using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngelController : MonoBehaviour {
    public Renderer[] AllRenderers;
    public Renderer OwnRenderer;

    // Path finding
    public Transform goal;
    private NavMeshAgent agent;

    private void Start() {
        goal = FindObjectOfType<PlayerController>().transform;
        agent = GetComponent<NavMeshAgent>();

        AllRenderers = GetComponentsInChildren<Renderer>();
        OwnRenderer = GetComponent<Renderer>();


    }
    void Update() {

        // IsVisibleFrom is a method from the RendererExtensions.cs script
        if (OwnRenderer.IsVisibleFrom(Camera.main)) {
            Debug.Log("Visible");
            foreach (Renderer renderer in AllRenderers) {
                renderer.enabled = true;
            }
            agent.enabled = false;
        } else {
            Debug.Log("Not visible");
            agent.enabled = true;
            agent.destination = goal.position;
            foreach (Renderer renderer in AllRenderers) {
                renderer.enabled = false;
            }
        }
    }


}
