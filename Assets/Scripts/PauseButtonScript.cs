using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour {

    // = true;

    public GameObject camera;
    public GameObject player;
    public GameObject sound;
    //public Button Pause_Button;

    public void Pause ()
    {

        /*if(gameObject.name == "PauseButton")
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                Debug.Log("left-click over a GUI element!");

            else Debug.Log("just a left-click!");
        }

        camera.GetComponent<HoleMovement>().pausedByButton = true;*/

        //pausedByButton = true;

        //sound.GetComponent<PauseSound>().paused = !sound.GetComponent<PauseSound>().paused;
        //player.GetComponent<PauseMenu>().paused = !player.GetComponent<PauseMenu>().paused;
        //camera.GetComponent<HoleMovement>().pausedByButton = true;


        if (player.GetComponent<PauseMenu>().paused == false)
        {
            player.GetComponent<PauseMenu>().paused = true;
            camera.GetComponent<HoleMovement>().pausedByButton = true;
            sound.GetComponent<PauseSound>().paused = true;
        }

        else
        {
            player.GetComponent<PauseMenu>().paused = false;
            camera.GetComponent<HoleMovement>().pausedByButton = true;
            sound.GetComponent<PauseSound>().paused = false;
        }

        //pausedByButton = false;

    }

}
