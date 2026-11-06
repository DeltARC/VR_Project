
using UnityEngine;

public class PotionVisuals : MonoBehaviour
{
    [Header("Water")]
    [SerializeField] public Transform water;
    [SerializeField] private Renderer waterRenderer;

    private Material originalMaterial;

    private void Awake()
    {
        originalMaterial = waterRenderer.material;
    }

    public void UpdatePotionVisuals(Material ingredientMaterial)
    {
        waterRenderer.material = ingredientMaterial;
    }

    public void ResetPotionVisuals()
    {
        waterRenderer.material = originalMaterial;
    }
}
