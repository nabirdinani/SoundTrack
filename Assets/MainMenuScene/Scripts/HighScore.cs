using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public static int yourScore;
    public static int hiscore;
    public Text PlayerScore;
    public Text HiScore;

    // Use this for initialization
    void Start () {
        hiscore = PlayerPrefs.GetInt("HighScore");

        if (yourScore > hiscore)
        {
            PlayerPrefs.SetInt("HighScore", yourScore);
            PlayerPrefs.Save();
        }

        PlayerScore.text = "YOUR SCORE\n" + yourScore;
        //PlayerPrefs.SetInt("HighScore", hiscore);
        //PlayerPrefs.Save();
        HiScore.text = "HIGH SCORE\n" + PlayerPrefs.GetInt("HighScore");


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
