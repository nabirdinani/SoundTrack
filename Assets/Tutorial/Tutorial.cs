using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Tutorial : MonoBehaviour
{

    public GameObject laser1;
    public GameObject laser2;
    public GameObject player;
    public GameObject collectible;
   
    public AudioSource audio1;


    Vector3 laser1Position;
    Vector3 laser2Position;
    int position = 0;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount == 30)
        {
            player.transform.position = new Vector3(2, player.transform.position.y, player.transform.position.z);
        }
        if (Time.frameCount == 90)
        {
            player.transform.position = new Vector3(0, player.transform.position.y, player.transform.position.z);
        }
        if (Time.frameCount == 150)
        {
            player.transform.position = new Vector3(-2, player.transform.position.y, player.transform.position.z);
        }
        if (Time.frameCount == 240)
        {
            player.transform.position = new Vector3(0, player.transform.position.y, player.transform.position.z);
        }
        if (Time.frameCount == 330)
        {
            audio1.panStereo = -1;
            player.transform.position = new Vector3(-2, player.transform.position.y, player.transform.position.z);
        }
        if (Time.frameCount == 420)
        {
            audio1.panStereo = 0;
            player.transform.position = new Vector3(0, player.transform.position.y, player.transform.position.z);
        }
        if (Time.frameCount == 510)
        {
            audio1.panStereo = 1;
            player.transform.position = new Vector3(2, player.transform.position.y, player.transform.position.z);
        }
        if (Time.frameCount == 600)
        {
            player.transform.position = new Vector3(0, player.transform.position.y, player.transform.position.z);
        }
        if (Time.frameCount == 650)
        {
            audio1.panStereo = 0;
        }
        if (Time.frameCount == 850)
        {
            SceneManager.LoadScene(1);
        }
    }



    void changeSound(int random)
    {
        if (random == 0)
        {
            
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
