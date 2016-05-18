using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject Pause_UI;
    //public GameObject MainCamera;

    public bool paused = false;


    //public GameObject go;
    public SwipeScript toggle;
    //private BGLooper toggle2;

    // Use this for initialization
    void Start () {
        Pause_UI.SetActive(false);
        toggle = GetComponent<SwipeScript>();

        //go = GameObject.Find("BGLooper");
        //go.transform.Translate(0, 1, 0);
        //toggle2 = go.GetComponent<BGLooper>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
        }

        if(paused)
        {
            //MainCamera.GetComponent
            Pause_UI.SetActive(true);
            Time.timeScale = 0;
            toggle.enabled = !toggle.enabled;
            //toggle2.enabled = !toggle2.enabled;
        }
        else
        {
            //MainCamera.SetActive(true);
            Pause_UI.SetActive(false);
            Time.timeScale = 1;
            toggle.enabled = true;
            //toggle2.enabled = true;
        }
	
	}
}
