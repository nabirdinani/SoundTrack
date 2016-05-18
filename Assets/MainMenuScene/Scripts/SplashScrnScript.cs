using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections;

public class SplashScrnScript : MonoBehaviour {
    float time = 1;
    public AudioSource beep;
    //public AudioClip beep;

    void Load ()
    {
    }

    void playSound ()
    {
        beep.Play();
    }

	// Use this for initialization
	void Start () {
        Invoke("playSound", (float) 0.8);
        //Invoke("Load", 5);
    }
	
	// Update is called once per frame
	void Update () {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else {
            SceneManager.LoadScene(1);
        }
    }
}
