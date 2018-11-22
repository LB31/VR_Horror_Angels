using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngelController : MonoBehaviour {
    private Renderer renderer;

    // Path finding
    public Transform goal;
    private NavMeshAgent agent;

    private void Start() {
        renderer = GetComponent<Renderer>();
        agent = transform.parent.GetComponent<NavMeshAgent>();

        
    }
    void Update() {
        
        // IsVisibleFrom is a method from the RendererExtensions.cs script
        if (renderer.IsVisibleFrom(Camera.main)) {
            Debug.Log("Visible");
            agent.enabled = false;
        } else {
            Debug.Log("Not visible");
            agent.enabled = true;
            agent.destination = goal.position;
        }
    }


}
