using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicEnd : MonoBehaviour
{
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
