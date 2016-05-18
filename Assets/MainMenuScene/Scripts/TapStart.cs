using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TapStart : MonoBehaviour {

    public int sceneToStart = 2;
    //public Touch touch = Input.touches[0];

    public LayerMask layerMask;

    public void openHelpPanel()
    {
        GameObject help_panel = GameObject.Find("help_panel");
        help_panel.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        help_panel.GetComponent<Animator>().Play("opening_pane", 0);
    }

    // Use this for initialization
    void Start () {
        //Touch touch = Input.touches[0];
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene(sceneToStart);
        }

        //Touch touch = Input.touches[0];
        /*if (Input.touchCount == 1)
        {
            if(touch.phase == TouchPhase.Ended)
            {
                SceneManager.LoadScene(sceneToStart);
            }
        }

        if (Input.touchCount > 1)
        {
            if (touch.phase == TouchPhase.Ended)
            {
                openHelpPanel();
            }
        }*/

    }
}
