using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    public AudioSource Audio;
    public AudioClip[] AudioTracks;

    public AngelController angelController;

    private float t;
    public float timeToRepeat = 7;

    private static System.Random random = new System.Random();

    public static float NormalDist(float mean = 0, float stddev = 1) {
        float x1 = 1 - (float)random.NextDouble();
        float x2 = 1 - (float)random.NextDouble();
        float r = Mathf.Sqrt((float)(-2.0 * Mathf.Log(x1))) * Mathf.Cos((float)(2.0 * Mathf.PI * x2));

        return r * stddev + mean;
    }

    private float TimingOffset(float mean = 0, float stddev = 1) {
        // return a random offset around 0 to start timing from
        return Mathf.Clamp(NormalDist(mean, stddev), -timeToRepeat, timeToRepeat);
    }

    // Use this for initialization
    void Start () {
        t = TimingOffset();
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (t > timeToRepeat) {
            t = TimingOffset();
            int randomNumber = (int)Random.Range(0f, AudioTracks.Length - 1);
            if (angelController != null && !angelController.AngelFound) {
                Audio.clip = AudioTracks[randomNumber];
                Audio.Play();
            }
            if (angelController == null) {
                Audio.clip = AudioTracks[randomNumber];
                Audio.Play();
            }
        }
	}
}
