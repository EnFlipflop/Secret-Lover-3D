using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [Header("Movement settings")]
    [Tooltip("The player's movement speed")]
    [SerializeField] private float moveSpeed = 3;
    
    private Rigidbody rb;
    private Vector3 direction;
    private float horizontal;
    private float vertical;
    

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        direction = horizontal * transform.TransformDirection(Vector3.right) + vertical * transform.TransformDirection(Vector3.forward);
        rb.linearVelocity = direction.normalized * moveSpeed;
    }
}
