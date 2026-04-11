using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuUI, settingsUI;
    void Start()
    {
        
    }

    public void Play()
    {
        
    }

    public void Settings()
    {
        settingsUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void Back()
    {
        settingsUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
