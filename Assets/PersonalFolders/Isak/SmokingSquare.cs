using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SmokingSquare : MonoBehaviour
{
    public GameObject interactUI;
    public GameObject cigg;
    private GameManager gameManager;
    private bool canSmoke;
    void Start()
    {
        gameManager = GameManager.Instance;
    }
    
    void Update()
    {
        if (!canSmoke)
            return;
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.CiggHint();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        Debug.Log("Smoking Square");
        canSmoke = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        canSmoke = false;
    }

    
}
