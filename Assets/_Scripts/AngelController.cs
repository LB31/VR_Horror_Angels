using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngelController : MonoBehaviour {
    public GameObject AngelModels;

    //public Renderer[] AllRenderers;
    public Renderer OwnRenderer;
    // All enemy AIs in the game
    public List<GameObject> AllAngels;

    // Path finding
    public Transform goal;
    private NavMeshAgent agent;

    public bool AngelFound;

    private bool CrashedPlayer;
    private float t;

    private void Start() {
        goal = FindObjectOfType<PlayerController>().transform;
        agent = GetComponent<NavMeshAgent>();

        // Finds the other angels
        foreach(AngelController angelInstance in FindObjectsOfType<AngelController>()) {
            if (!angelInstance.gameObject.Equals(gameObject)) {
                AllAngels.Add(angelInstance.gameObject);
            }
            
        }
       
        OwnRenderer = GetComponent<Renderer>();
        //AllRenderers = AngelModels.GetComponentsInChildren<Renderer>();

    }
    private void Update() {
        if (!CrashedPlayer) {
            float distanceToPlayer = Vector3.Distance(Camera.main.transform.position, transform.position);
            // Decides which angel model should be shown
            bool modelAttacks = (distanceToPlayer > 2.5) ? false : true;

            // IsVisibleFrom is a method from the RendererExtensions.cs script
            if (OwnRenderer.IsVisibleFrom(Camera.main)) {
                if (!AngelFound) {
                    // Show the angel when he is seen
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

        
        //Vector3 heading = GameObject.FindWithTag("Respawn").transform.position - transform.position;
        //float dirNum = OtherObjectLeftOrRight(transform.forward, heading, transform.up);

        


    }

    // Source: https://forum.unity.com/threads/left-right-test-function.31420/
    private float OtherObjectLeftOrRight(Vector3 fwd, Vector3 targetDir, Vector3 up) {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0f) {
            // right
            return 1f;
        } else if (dir < 0f) {
            // left
            return -1f;
        } else {
            // Exactly on the same line
            return 0f;
        }
    }


    private void ChangeAngelVisibility(bool toAttack, bool hideAll) {
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
        // If the angel crashes the player without being seen
        if (other.gameObject.CompareTag("Player") && !AngelFound) {

            CrashedPlayer = true;
            agent.enabled = false;
            ChangeAngelVisibility(true, false);
            AngelFound = true;
        }
    }


}
