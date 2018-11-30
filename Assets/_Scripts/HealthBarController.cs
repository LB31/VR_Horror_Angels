using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    public Image LoadingBar;
 

	// Use this for initialization
	void Start () {
        LoadingBar.fillAmount = 1;

    }


    public void DecreaseLife(float amount) {
        LoadingBar.fillAmount -= amount / 100;
    }

}
