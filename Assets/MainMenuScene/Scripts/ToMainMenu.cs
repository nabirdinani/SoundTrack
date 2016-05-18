using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ToMainMenu : MonoBehaviour {

    public int sceneTarget = 1;

	// Use this for initialization
	void Start () {
	
	}

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneTarget);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
