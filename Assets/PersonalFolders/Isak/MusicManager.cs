using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public EventReference ambianceRef;
    private EventInstance ambianceInstance;
    void Start()
    {
        ambianceInstance = RuntimeManager.CreateInstance(ambianceRef);
        ambianceInstance.start();
    }
}
