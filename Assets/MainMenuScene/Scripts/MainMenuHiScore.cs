using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuHiScore : MonoBehaviour {

    public Text HiScore;

	// Use this for initialization
	void Start () {

        HiScore.text = "High Score:\n" + PlayerPrefs.GetInt("HighScore");

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
