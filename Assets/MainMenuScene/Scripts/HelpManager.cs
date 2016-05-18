using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HelpManager : MonoBehaviour {

    // Help pages
    private GameObject help_panel;
    private GameObject main_info_panel;
    private GameObject dumb_panel;
    private GameObject[] help_pages;

    // Navigation buttons
    private Button previous_button;
    private Button next_button;

    private int number_of_help_pages = 2;
    private int current_help_index;


	// Use this for initialization
	void Start ()
    {
        help_panel = GameObject.Find ("help_panel");
        main_info_panel = GameObject.Find ("main_info_panel");
        dumb_panel = GameObject.Find ("dumb_panel");
        
        help_pages = new GameObject[number_of_help_pages];
        help_pages[0] = main_info_panel;
        help_pages[1] = dumb_panel;

        HideAllPages();
        ShowPage(0);
        current_help_index = 0;

        previous_button = GameObject.Find ("help_previous_button").GetComponent<Button> ();
        next_button = GameObject.Find ("help_next_button").GetComponent<Button> ();
        previous_button.interactable = false;
    }
	
    
    void Update ()
    {
        
    }


    // Hides the current page and shows the new page passed as argument
    void ChangeToPage(int next_page)
    {
        HidePage(current_help_index);
        current_help_index = next_page;
        ShowPage(current_help_index);
    }


	// Hides all the help pages
	void HideAllPages ()
    {
        for (int i = 0; i < number_of_help_pages; i++)
            HidePage(i);
        current_help_index = 0;
    }


    // Hides the page number page
    void HidePage(int page)
    {
        help_pages[page].GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }


    // Shows page number page
    void ShowPage(int page)
    {
        help_pages[page].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }


    // Goes to the next page of the help menu
    public void nextPage ()
    {
        if (current_help_index < number_of_help_pages - 1)
        {
            // change pages
            HidePage(current_help_index);
            current_help_index++;
            ShowPage(current_help_index);

            // enable previous button
            if (current_help_index == 1)
                previous_button.interactable = true;

            if (current_help_index == number_of_help_pages - 1)
                next_button.interactable = false;
        }
    }


    // Goes to the previous page in the help menu
    public void previousPage ()
    {
        if (current_help_index > 0)
        {
            // change pages
            HidePage(current_help_index);
            current_help_index--;
            ShowPage(current_help_index);

            // enable next button
            if (current_help_index == number_of_help_pages - 2)
                next_button.interactable = true;

            if (current_help_index == 0)
                previous_button.interactable = false;
        }
    }


    // Closes the help menu
    public void closeMenu ()
    {
        Debug.Log("Closing menu");
        help_panel.GetComponent<Animator>().Play("closing_panel", 0);
    }
}
