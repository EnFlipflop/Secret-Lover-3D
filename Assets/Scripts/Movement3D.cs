using FMODUnity;
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
    
    //isaks del
    private bool isMoving;
    [SerializeField] private float stepCD = 0.5f, paramCD = 0.3f;
    private float stepTimer, paramTimer;
    public SoundScriptable sounds;
    public float rayDistance = 0.4f;
    
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
        
        
        //Fotsteg :) 
        bool currentlyMoving = direction.magnitude > 0.1f;
        if (currentlyMoving)
        {
            stepTimer += Time.fixedDeltaTime;

            if (stepTimer >= stepCD)
            {
                RuntimeManager.PlayOneShot(sounds.footsteps);
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }
        
        
        if (!isMoving && currentlyMoving)
        {
            Debug.Log("Started");
            StartWalking();
        }
        
        if (isMoving && !currentlyMoving)
        {
            Debug.Log("Stopped");
            StopWalking();
        }
        
        
        isMoving = currentlyMoving;
        
        paramTimer += Time.fixedDeltaTime;

        if (paramTimer >= paramCD)
        {
            Parameter();
            stepTimer = 0f;
        }
    }

    private void StartWalking()
    {
        RuntimeManager.PlayOneShot(sounds.startFootstep);
    }

    private void StopWalking()
    {
        RuntimeManager.PlayOneShot(sounds.stopFootstep);
    }
    private void Parameter()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Stone"))
            {
                RuntimeManager.StudioSystem.setParameterByName("Material", 0);
            }
            else if (hit.collider.CompareTag("Carpet"))
            {
                RuntimeManager.StudioSystem.setParameterByName("Material", 1);
            }
        }
    }
}
