using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    public AudioSource Audio;
    public AudioClip[] AudioTracks;

    private AngelController angelController;

    private float t;
    private float timeToRepeat = 5;

    // Use this for initialization
    void Start () {
        angelController = GetComponent<AngelController>();
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if(t > timeToRepeat && !angelController.AngelFound) {
            t = 0;
            int randomNumber = (int)Random.Range(0f, 6f);
            Audio.clip = AudioTracks[randomNumber];
            Audio.Play();
        }
	}
}
