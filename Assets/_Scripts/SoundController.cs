using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    public AudioSource Audio;
    public AudioClip[] AudioTracks;

    public AngelController angelController;

    private float t;
    public float timeToRepeat = 5;

    // Use this for initialization
    void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if(t > timeToRepeat) {
            t = 0;
            int randomNumber = (int)Random.Range(0f, AudioTracks.Length - 1);
            if (angelController != null && !angelController.AngelFound) {
                Audio.clip = AudioTracks[randomNumber];
                Audio.Play();
            }
            if(angelController == null) {
                Audio.clip = AudioTracks[randomNumber];
                Audio.Play();
            }

 
        }
	}
}
