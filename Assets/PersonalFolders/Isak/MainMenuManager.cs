using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuUI, settingsUI, tutorialUI;
    void Start()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Cinematic");
    }

    public void Settings()
    {
        settingsUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }
    
    public void Tutorial()
    {
        tutorialUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void Back()
    {
        tutorialUI.SetActive(false);
        settingsUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
