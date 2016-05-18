using UnityEngine;
using System.Collections;

public class PauseBGLoop : MonoBehaviour
{

    static bool paused = false;


    //public GameObject go;
    private BGLooper toggle;
    //private BGLooper toggle2;

    // Use this for initialization
    void Start()
    {
 
        toggle = GetComponent<BGLooper>();

        //go = GameObject.Find("BGLooper");
        //go.transform.Translate(0, 1, 0);
        //toggle2 = go.GetComponent<BGLooper>();
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
            toggle.enabled = !toggle.enabled;
            //toggle2.enabled = !toggle2.enabled;
        }
        else
        {
            toggle.enabled = true;
            //toggle2.enabled = true;
        }

    }
}