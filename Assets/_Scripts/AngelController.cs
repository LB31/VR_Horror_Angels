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
        agent.destination = goal.position;
        //Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        //bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 
        //    && screenPoint.y > 0 && screenPoint.y < 1;
        //print(screenPoint.y);
        //if (onScreen) print("On screen");
        //else print("Not on screen");

        // IsVisibleFrom is a method from the RendererExtensions.cs script
        if (renderer.IsVisibleFrom(Camera.main)) Debug.Log("Visible");
        else Debug.Log("Not visible");
    }


}
