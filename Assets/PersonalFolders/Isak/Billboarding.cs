using UnityEngine;

public class Billboarding : MonoBehaviour
{
    void Update() 
    {
        transform.LookAt(Camera.main.transform.position, -Vector3.up);
    }
}
