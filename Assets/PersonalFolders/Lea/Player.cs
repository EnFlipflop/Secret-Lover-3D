using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("The range at which the player can interact with Interactables")]
    [SerializeField] private float interactRange = 3;
    
    private Person currentPerson;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactRange) && hit.collider.CompareTag("Person"))
        {
            currentPerson = hit.collider.GetComponent<Person>();
            currentPerson.OnHover();
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (transform.forward * interactRange));
    }
}
