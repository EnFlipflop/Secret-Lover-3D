using System;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseUI;
    public bool isPaused;

    private void Start()
    {
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.upptagen == false && Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
                Pause(true);
            else
            {
                Pause(false);
            }
            
        }

    }

    private void Pause(bool state)
    {
        if (GameManager.Instance.letter.activeInHierarchy)
            return;
        isPaused = state;
        pauseUI.SetActive(state);
        GameManager.Instance.movement3D.enabled = !state;
        GameManager.Instance.camera3D.enabled = !state;
        if (!state)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
        Cursor.visible = !state;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Pause(false);
    }
}
