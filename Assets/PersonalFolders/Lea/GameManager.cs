using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [NonSerialized] public Movement3D movement3D;
    [NonSerialized] public Camera3D camera3D;

    [NonSerialized] public bool interacting;
    
    private static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }
    }

    public void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (movement3D == null)
        {
            movement3D = player.GetComponentInChildren<Movement3D>();
        }
        
        if (camera3D == null)
        {
            camera3D = player.GetComponentInChildren<Camera3D>();
        }
    }

    public void StopInteracting()
    {
        interacting = false;
    }
}
