using FMODUnity;
using UnityEngine;
[CreateAssetMenu(fileName = "Soundholder", menuName = "Soundholder", order = 1)]
public class SoundScriptable : ScriptableObject
{
    [Header("Player")] public EventReference footsteps, stopFootstep, startFootstep; 
    public EventReference interact;

    [Header("UI")] public EventReference UIHover;
    public EventReference UIClick, PaperClick;

}
