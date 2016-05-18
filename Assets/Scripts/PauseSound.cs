using UnityEngine;
using System.Collections;

public class PauseSound : MonoBehaviour
{

    public bool paused = false;


    public AudioSource toggle;

    // Use this for initialization
    void Start()
    {
        toggle = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
        }

        if (paused)
        {
            //Time.timeScale = 0;
            //toggle.enabled = !toggle.enabled;
            toggle.Pause();

        }
        else
        {
            //Time.timeScale = 1;
            //toggle.enabled = true;
            toggle.UnPause();
        }

    }
}