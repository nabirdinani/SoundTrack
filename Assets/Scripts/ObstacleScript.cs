using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour {

    public GameObject camera;
    public GameObject player;

    public float distanceToPlayer = 10f;

    Animator anim;
    
    Vector3 initialPosition;

    bool active;

    void GameOver()
    {
        SceneManager.LoadScene(3);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            player.GetComponent<SwipeScript>().disableMove();
            anim.SetBool("Trip", true);
            //player.GetComponent<SwipeScript>().enabled = false;
            HighScore.yourScore = Mathf.RoundToInt(HoleMovement.score);
            HoleMovement.score = 0;
            /*if(anim.GetBool("Trip") == false)
            {
                SceneManager.LoadScene(2);
            }*/
            //WaitUntil(anim.GetBool("Trip") == true);
            //SceneManager.LoadScene(3);

            /*Leaving just enough time for the trip animation before game over*/
            Invoke("GameOver", 0.75f);

        }

        if (other.tag == "BGLooper")
        {            
            this.GetComponent<SpriteRenderer>().enabled = false;
            //this.transform.position = initialPosition;
            camera.GetComponent<HoleMovement>().setShowLasres(false);
        }
    }

    void Start()
    {
        active = camera.GetComponent<HoleMovement>().getShowLasers();

        initialPosition = this.transform.position;

        anim = player.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        active = camera.GetComponent<HoleMovement>().getShowLasers();

        if (active)
        {            
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            this.transform.position = new Vector3(transform.position.x, player.transform.position.y + distanceToPlayer, transform.position.z);
        }
	}
}
