using System.Collections;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicEnd : MonoBehaviour
{
    
    public EventReference cutsceneEventRef;
    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(16);
        SceneManager.LoadScene("PS2");
    }
}
