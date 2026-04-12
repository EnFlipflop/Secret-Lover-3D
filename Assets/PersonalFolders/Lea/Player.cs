using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("The range at which the player can interact with Interactables")]
    [SerializeField] private float interactRange = 3;
    private Person currentPerson;
    public GameObject letter, coat;
    
    private void Update()
    {
        if (!GameManager.Instance.interacting)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                GameManager.Instance.interacting = true;
                letter.gameObject.SetActive(true);
                coat.gameObject.SetActive(false);
            }
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactRange) && hit.collider.CompareTag("Person"))
            {
                currentPerson = hit.collider.GetComponent<Person>();
                currentPerson.OnHover();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentPerson.OnInteract();
                    GameManager.Instance.movement3D.StopMoving();
                    GameManager.Instance.interacting = true;
                    coat.gameObject.SetActive(false);
                }
            }
            else
            {
                if (currentPerson)
                {
                    currentPerson.OnHoverEnd();
                    currentPerson = null;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                currentPerson?.OnInteractEnd();
                GameManager.Instance.interacting = false;
                letter.gameObject.SetActive(false);
                coat.gameObject.SetActive(true);
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (transform.forward * interactRange));
    }
    
}
