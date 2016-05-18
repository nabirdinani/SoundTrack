using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HoleMovement : MonoBehaviour {

    public GameObject laser1;
    public GameObject laser2;
    public GameObject player;
    public GameObject collectible;
    public GameObject[] backGrounds;
    public GameObject[] darkGrounds;

    public Sprite[] backGroundSprites;
    
    public AudioSource audio1;

    public int minMusicChange;
    public int maxMusicChange;
    public int minBlackPhase;
    public int maxBlackPhase;
    public int minStayBlack;
    public int maxStayBlack;
    public int minCollectibleSpawn;
    public int maxCollectibleSpawn;

    public Text scoreText;

    Vector3 laser1Position;
    Vector3 laser2Position;

    int musicChangeTime;
    int blackPhaseTime;
    int stayBlackTime;
    int collectibleSpawnTime;

    int position = 1;
    public static float score = 0;
    public static int highScore;

    bool black = false;
    bool showLasers = false;

    bool paused = false;

    //public GameObject pauseButtonScript;
    //public Button PauseButton;
    public bool pausedByButton = false;

    // Created for the game menu, in where there is no collectibles, lasers nor music changes
    public bool inMenu = false;

	// Use this for initialization
	void Start () {
        musicChangeTime = Time.frameCount + Random.Range(minMusicChange, maxMusicChange);
        blackPhaseTime = Time.frameCount + Random.Range(minBlackPhase, maxBlackPhase);
        stayBlackTime = Time.frameCount + Random.Range(minStayBlack, maxStayBlack);
        collectibleSpawnTime = Time.frameCount + Random.Range(minCollectibleSpawn, maxCollectibleSpawn);

        if (inMenu)
        {
            showLasers = false;
            scoreText.rectTransform.localScale = new Vector3(0, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
            musicChangeTime = Time.frameCount + Random.Range(minMusicChange, maxMusicChange);
            blackPhaseTime = Time.frameCount + Random.Range(minBlackPhase, maxBlackPhase);
            stayBlackTime = Time.frameCount + Random.Range(minStayBlack, maxStayBlack);
            collectibleSpawnTime = Time.frameCount + Random.Range(minCollectibleSpawn, maxCollectibleSpawn);
            //pausedByButton = false;
        }

        if (pausedByButton == true)
        {
            paused = !paused;
            musicChangeTime = Time.frameCount + Random.Range(minMusicChange, maxMusicChange);
            blackPhaseTime = Time.frameCount + Random.Range(minBlackPhase, maxBlackPhase);
            stayBlackTime = Time.frameCount + Random.Range(minStayBlack, maxStayBlack);
            collectibleSpawnTime = Time.frameCount + Random.Range(minCollectibleSpawn, maxCollectibleSpawn);
            pausedByButton = false;
        }

        if (!showLasers && !paused && (Time.frameCount == musicChangeTime))
        {
            int random = Random.Range(0, 3);
            changeSound(random);
            changePosition(random);
            if (inMenu)
                changePlayerPosition(random);
            musicChangeTime = Time.frameCount + Random.Range(minMusicChange, maxMusicChange);
        }
        else if (showLasers && (Time.frameCount == musicChangeTime))
        {
            musicChangeTime = Time.frameCount + Random.Range(minMusicChange, maxMusicChange);
        }

        if (!black && !paused && (Time.frameCount == blackPhaseTime))
        {
            black = true;
            foreach (GameObject dg in darkGrounds)
            {
                dg.GetComponent<SpriteRenderer>().enabled = true;
            }
            blackPhaseTime = Time.frameCount + Random.Range(minBlackPhase, maxBlackPhase);
            stayBlackTime = Time.frameCount + Random.Range(minStayBlack, maxStayBlack);
        }
        else if (black && (Time.frameCount == blackPhaseTime))
        {
            blackPhaseTime = Time.frameCount + Random.Range(minBlackPhase, maxBlackPhase);
        }

        if (black && !paused && (Time.frameCount == stayBlackTime))
        {
            black = false;
            foreach (GameObject dg in darkGrounds)
            {
                dg.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (!inMenu)
                showLasers = true;
            stayBlackTime = Time.frameCount + Random.Range(minStayBlack, maxStayBlack);
        }
        else if (!black && (Time.frameCount == stayBlackTime))
        {
            stayBlackTime = Time.frameCount + Random.Range(minStayBlack, maxStayBlack);
        }

        if (Time.frameCount == collectibleSpawnTime && !paused)
        {
            int random = Random.Range(0, 3);

            if (!inMenu)
                spawnCollectible(random);

            collectibleSpawnTime = Time.frameCount + Random.Range(minCollectibleSpawn, maxCollectibleSpawn);
        }
        else if (!black && (Time.frameCount == collectibleSpawnTime))
        {
            collectibleSpawnTime = Time.frameCount + Random.Range(minCollectibleSpawn, maxCollectibleSpawn);
        }

        calculateScore();
        if (!black)
        {
            scoreText.text = "Score:\n" + Mathf.RoundToInt(score);
        }
        else
        {
            scoreText.text = "Score:----";
        }

        if (((int)(score) % 100) == 0 && score != 0)
        {
            audio1.pitch = audio1.pitch + 0.001f;
        }
    }


    void changePlayerPosition(int random)
    {
        //player.transform.position = new Vector3(transform.position.x - 2.1f, transform.position.y, transform.position.z);
        float difference = 0;

        if (random == 0)
            difference = player.transform.position.x - (-2);
        else if (random == 1)
            difference = player.transform.position.x;
        else if (random == 2)
            difference = player.transform.position.x + (-2);

        player.transform.position = new Vector3(player.transform.position.x - difference, player.transform.position.y, player.transform.position.z);
    }

    void changePosition(int random)
    {
        if (random == 0)
        {
            position = 0;
            laser1Position = new Vector3(0, player.transform.position.y + 1, 10);
            laser2Position = new Vector3(2, player.transform.position.y + 1, 10);
            laser1.transform.position = laser1Position;
            laser2.transform.position = laser2Position;
            foreach (GameObject bg in backGrounds){
                bg.GetComponent<SpriteRenderer>().sprite = backGroundSprites[0];
            }
        }
        else if (random == 1)
        {
            position = 1;
            laser1Position = new Vector3(2, player.transform.position.y + 1, 10);
            laser2Position = new Vector3(-2, player.transform.position.y + 1, 10);
            laser1.transform.position = laser1Position;
            laser2.transform.position = laser2Position;

            foreach (GameObject bg in backGrounds)
            {
                bg.GetComponent<SpriteRenderer>().sprite = backGroundSprites[1];
            }
        }
        else if (random == 2)
        {
            position = 2;
            laser1Position = new Vector3(0, player.transform.position.y + 1, 10);
            laser2Position = new Vector3(-2, player.transform.position.y + 1, 10);
            laser1.transform.position = laser1Position;
            laser2.transform.position = laser2Position;

            foreach (GameObject bg in backGrounds)
            {
                bg.GetComponent<SpriteRenderer>().sprite = backGroundSprites[2];
            }
        }
    }

    void changeSound(int random)
    {
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

    public bool getBlack()
    {
        return black;
    }

    public bool getShowLasers()
    {
        return showLasers;
    }

    public void setShowLasres(bool newShowLasers)
    {
        if (!inMenu)
            showLasers = newShowLasers;
    }

    public void calculateScore()
    {
        if (position == 0)
        {
            if (player.transform.position.x < 0 && !paused)
            {
                score += 0.1f;
            }
        }
        else if (position == 1)
        {
            if (player.transform.position.x == 0 && !paused)
            {
                score += 0.1f;
            }
        }
        else if (position == 2)
        {
            if (player.transform.position.x > 0 && !paused)
            {
                score += 0.1f;
            }
        }        
    }

    public void addScore(float s)
    {
        score += s;
    }

    public void spawnCollectible (int position)
    {
        if (position == 0)
        {
            Instantiate(collectible, new Vector3(-2.1f, transform.position.y + 5.5f, 0f), Quaternion.identity);
        }

        if(position == 1)
        {
            Instantiate(collectible, new Vector3(0f, transform.position.y + 5.5f, 0f), Quaternion.identity);
        }

        if(position == 2)
        {
            Instantiate(collectible, new Vector3(2.1f, transform.position.y + 5.5f, 0f), Quaternion.identity);
        }
    }

    public void updateHighScore()
    {
        // not fancy, sorry
        if (inMenu)
            return;

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Mathf.RoundToInt(score));
        }
        highScore = PlayerPrefs.GetInt("HighScore");
    }
}
