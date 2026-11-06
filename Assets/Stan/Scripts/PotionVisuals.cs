using UnityEngine;

public class PotionVisuals : MonoBehaviour
{
    [Header("Water")]
    [SerializeField] public Transform water;
    [SerializeField] private Renderer waterRenderer;

    public void UpdatePotionVisuals(Material ingredientMaterial)
    {
        waterRenderer.material = ingredientMaterial;
        
    }
}