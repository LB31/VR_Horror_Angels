using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public float PlayerLife = 100;

    public GameObject AllAngelEnemies;

    public GameObject PauseUI;

    public GameObject DeadScreen;

    public GameObject TARDIS;
    public Transform PlayerTeleport;

    private bool pauseGame;

    private float t;

    public GameObject[] allTexts;

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

        if(PlayerLife <= 0) {
            DeadScreen.SetActive(true);
            AllAngelEnemies.SetActive(false);
            t += Time.deltaTime;
        }

        if(t >= 5) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            AllAngelEnemies.SetActive(true);
        }
    }

}
