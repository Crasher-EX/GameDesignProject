using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject comicBook;
    public GameObject pageFlip;
    public GameObject mainMenuPage;
    public GameObject levelSelectionPage1;

    [SerializeField] string neighboorhoodScene;

    public float menuWait;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EnableMenuAfterDelay());
    }

    IEnumerator EnableMenuAfterDelay()
    {
        yield return new WaitForSeconds(menuWait);
        mainMenuPage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //-------------MAIN MENU BUTTONS---------------
    public void playButton() //Play button functions
    {
        disableAllPages();
        levelSelectionPage1.SetActive(true);
    }

    public void quitButton() //Play button functions
    {
        Application.Quit();
    }


    //-------------LEVEL SELECTION BUTTONS---------------
    public void neighborhoodButton() //loads neighboorhood game scene
    {
        SceneManager.LoadScene(neighboorhoodScene);
    }



    //-------------OTHER BUTTONS/FUNCTIONS---------------
    public void backButton() //Back button functions, returns player back to main menu screen
    {
        disableAllPages();
        mainMenuPage.SetActive(true);
    }

    public void disableAllPages() //disables all pages
    {
        mainMenuPage.SetActive(false);
        levelSelectionPage1.SetActive(false);
    }
}
