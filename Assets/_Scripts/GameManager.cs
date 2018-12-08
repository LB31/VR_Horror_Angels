using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public float PlayerLife = 100;

    public GameObject AllAngelEnemies;

    public GameObject PauseUI;

    public bool pauseGame;


	// Use this for initialization
	void Start () {
        // Deactivates the enemies for the tutorials
        AllAngelEnemies.SetActive(false);
        // Starts the game in the menu
        PauseGame(true);

    }
	

	void Update () {
        // Pauses or resumes the game, when specific button is pushed
        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("o")) {
            PauseGame(pauseGame);
            PauseUI.SetActive(pauseGame);
            pauseGame = !pauseGame;
        }
    }


    public void PauseGame(bool pause) {
        int stop = 0;
        if (pause)
            stop = 0;
        else
            stop = 1;

        Time.timeScale = stop;
    }
}
