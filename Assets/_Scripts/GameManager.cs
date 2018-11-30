using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public float PlayerLife = 100;

    public GameObject AllAngelEnemies;


	// Use this for initialization
	void Start () {
        // Deactivates the enemies for the tutorials
        AllAngelEnemies.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
