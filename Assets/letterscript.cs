using System;
using UnityEngine;

public class letterscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        GameManager.Instance.upptagen = true;
        /*Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.Instance.camera3D.enabled = false;
        GameManager.Instance.movement3D.enabled = false;
        Debug.Log("På");*/
    }

    private void OnDisable()
    {
        GameManager.Instance.upptagen = false;
        /*Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.Instance.camera3D.enabled = true;
        GameManager.Instance.movement3D.enabled = true;*/
        Debug.Log("av");
        
    }
}
