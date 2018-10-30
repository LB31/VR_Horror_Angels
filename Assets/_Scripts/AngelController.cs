using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelController : MonoBehaviour {
    private Renderer renderer;

    private void Start() {
        renderer = GetComponent<Renderer>();
    }
    void Update() {

        //Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        //bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 
        //    && screenPoint.y > 0 && screenPoint.y < 1;
        //print(screenPoint.y);
        //if (onScreen) print("On screen");
        //else print("Not on screen");

        if (renderer.IsVisibleFrom(Camera.main)) Debug.Log("Visible");
        else Debug.Log("Not visible");
    }


}
