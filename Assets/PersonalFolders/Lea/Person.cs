using TMPro;
using UnityEngine;

public class Person : MonoBehaviour
{
    /*[Tooltip("The outline shader material")]
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private Color outlineColor;
    
    private MeshRenderer meshRenderer;
    private Material defaultMaterial;*/
    [SerializeField] private CharacterScriptable characterLines;
    [SerializeField] private GameObject interactText;
    [SerializeField] private GameObject conversationScreen;

    public int UniqueIdentifier;
    [SerializeField] private GameObject blodpöl;
    
    private void Start()
    {
        /*meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterial = meshRenderer.materials[1];
        
        outlineMaterial.color = outlineColor;*/
    }

    public void OnHover()
    {
        //meshRenderer.material = outlineMaterial;
        interactText.SetActive(true);
    }

    public void OnHoverEnd()
    {
        //meshRenderer.material = defaultMaterial;
        interactText.SetActive(false);
    }

    public void OnInteract()
    {
        GameManager.Instance.movement3D.enabled = false;
        GameManager.Instance.camera3D.enabled = false;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        interactText.SetActive(false);
        conversationScreen.SetActive(true);
    }

    public void OnInteractEnd()
    {
        GameManager.Instance.movement3D.enabled = true;
        GameManager.Instance.camera3D.enabled = true;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        interactText.SetActive(true);
        conversationScreen.SetActive(false);
    }

    public void Die(int identifier)
    {
        if (identifier == UniqueIdentifier)
        {
            //Instantiate()
            gameObject.SetActive(false);
        }
    }
    
}
