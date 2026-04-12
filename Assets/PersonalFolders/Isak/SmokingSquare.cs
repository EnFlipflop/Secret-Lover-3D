using System;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using FMODUnity;
using UnityEngine;

public class SmokingSquare : MonoBehaviour
{
    public GameObject interactUI, processingUI;
    public GameObject cigg;
    private GameManager gameManager;
    public SoundScriptable sounds;
    
    private bool canSmoke;
    void Start()
    {
        gameManager = GameManager.Instance;
        interactUI.SetActive(false);
        processingUI.SetActive(false);
    }
    
    void Update()
    {
        if (!canSmoke)
            return;
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.CiggHint();
            StartCoroutine(SmokeLock());
            RuntimeManager.PlayOneShot(sounds.Smoking);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        Debug.Log("Smoking Square");
        canSmoke = true;
        interactUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        canSmoke = false;
        interactUI.SetActive(false);
    }

    private IEnumerator SmokeLock()
    {
        canSmoke = false;
        interactUI.SetActive(false);
        processingUI.SetActive(true);
        GameManager.Instance.movement3D.enabled = false;
        GameManager.Instance.camera3D.enabled = false;
        yield return new WaitForSeconds(6);
        GameManager.Instance.movement3D.enabled = true;
        GameManager.Instance.camera3D.enabled = true;
        canSmoke = true;
        interactUI.SetActive(true);
        processingUI.SetActive(false);
    }
}
