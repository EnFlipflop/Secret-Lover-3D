using UnityEngine;

public class Person : MonoBehaviour
{
    [Tooltip("The outline shader material")]
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private Color outlineColor;
    
    private MeshRenderer meshRenderer;
    private Material defaultMaterial;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterial = meshRenderer.materials[1];
        
        outlineMaterial.color = outlineColor;
    }

    public void OnHover()
    {
        meshRenderer.material = outlineMaterial;
    }

    public void OnHoverEnd()
    {
        meshRenderer.material = defaultMaterial;
    }
}
