using UnityEngine;
using System.Collections;
using System;

public class TestPanStereo : MonoBehaviour {

    public AudioSource audio1;
    private float timeLeft = 3.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.frameCount % 90 == 0) // Music might change every 30 sseconds
        {
            changeSound();
        }
        
	}

    void changeSound()
    {
        int random = UnityEngine.Random.Range(0, 3);

        if (random == 0)
        {
            audio1.panStereo = -1;
        }
        else if (random == 1)
        {
            audio1.panStereo = 0;
        }
        else if (random == 2)
        {
            audio1.panStereo = 1;
        }
    }
}
