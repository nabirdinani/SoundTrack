using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HelpButton : MonoBehaviour {

    public LayerMask layerMask;

    public void openHelpPanel()
    {
        GameObject help_panel = GameObject.Find("help_panel");
        help_panel.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        help_panel.GetComponent<Animator>().Play("opening_pane", 0);
        //SceneManager.LoadScene(4);
    }
}
