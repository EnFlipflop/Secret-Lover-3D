using System.Collections;
using System.Security.Cryptography;
using FMODUnity;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private CharacterConversation CC; 
    public int UniqueIdentifier;

    public SoundScriptable sounds;

    private bool canInteractLocal = true;
    //[SerializeField] private GameObject blodpöl;
    
    private void Start()
    {
        /*meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterial = meshRenderer.materials[1];
        
        outlineMaterial.color = outlineColor;*/
    }

    public void OnHover()
    {
        //meshRenderer.material = outlineMaterial;
        if (!GameManager.Instance.interacting)
        {
            if (Stop == null)
                interactText.SetActive(true);
        }

        
    }

    public void OnHoverEnd()
    {
        //meshRenderer.material = defaultMaterial;
        interactText.SetActive(false);
    }

    public void OnInteract()
    {
        if (!canInteractLocal || GameManager.Instance.interacting)
            return;
        GameManager.Instance.upptagen = true;
        GameManager.Instance.movement3D.enabled = false;
        GameManager.Instance.camera3D.enabled = false;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        interactText.SetActive(false);
        conversationScreen.SetActive(true);
        CC = conversationScreen.GetComponent<CharacterConversation>();
        CC.StartCharacterInteraction();
    }

    private Coroutine Stop;
    public void OnInteractEnd()
    {
        if (Stop == null)
        {
            canInteractLocal = false;
            Stop = StartCoroutine(stopinteract());
        }
        /*GameManager.Instance.movement3D.enabled = true;
        GameManager.Instance.camera3D.enabled = true;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        interactText.SetActive(true);
        conversationScreen.SetActive(false);*/
    }

    public void Die(int identifier)
    {
        Debug.Log("Die" + identifier + UniqueIdentifier);
        if (identifier == UniqueIdentifier)
        {
            
            Instantiate(GameManager.Instance.bloodsplatters[Random.Range(0, GameManager.Instance.bloodsplatters.Length)], 
                transform.position, Quaternion.Euler(90, Random.Range(0, 360), 0));
            RuntimeManager.PlayOneShotAttached(sounds.GunShot, gameObject);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator stopinteract()
    {
        CC.End();
        yield return new WaitForSeconds(2f);
        GameManager.Instance.movement3D.enabled = true;
        GameManager.Instance.camera3D.enabled = true;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.Instance.coatIcon.SetActive(true);
        interactText.SetActive(true);
        conversationScreen.SetActive(false);
        GameManager.Instance.interacting = false;
        canInteractLocal = true;
        GameManager.Instance.upptagen = false;
        GameManager.Instance.coatIcon.SetActive(true);
        Stop = null;
    }
    
}
