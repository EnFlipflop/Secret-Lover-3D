using UnityEngine;

public class Camera3D : MonoBehaviour
{
    [Header("Camera settings")]
    [Tooltip("Camera sensitivity")]
    [SerializeField] private float sensitivity = 50;
    [Tooltip("X-Axis sensitivity modifier")]
    [SerializeField] private float sensModX = 2;
    [Tooltip("Y-Axis sensitivity modifier")]
    [SerializeField] private float sensModY = 3;
    [Tooltip("Maximum angle for X-Axis camera rotation")]
    [SerializeField] private float maxAngle = 40;
    
    private Camera camera;

    private float sensX => sensitivity * sensModX;
    private float sensY => sensitivity * sensModY;
    
    private float rotX;
    private float rotY;
    
    private void Start()
    {
        camera = GetComponentInChildren<Camera>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        rotY += Input.GetAxisRaw("Mouse X") * sensX * Time.fixedDeltaTime;
        rotX -= Input.GetAxisRaw("Mouse Y") * sensY * Time.fixedDeltaTime;
        
        rotX = Mathf.Clamp(rotX, -maxAngle, maxAngle);
        
        camera.transform.localRotation = Quaternion.Euler(rotX, 0, 0);
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
