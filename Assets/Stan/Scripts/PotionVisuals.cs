using UnityEngine;

public class PotionVisuals : MonoBehaviour
{
    [Header("Water")]
    [SerializeField] public Transform water;
    [SerializeField] private Renderer waterRenderer;

    [Header("Feedback")]
    [SerializeField] private float heightIncrease = 0.02f;

    public void UpdatePotionVisuals(Material ingredientMaterial)
    {
        water.localPosition += Vector3.up * heightIncrease;
        waterRenderer.material = ingredientMaterial;
    }
}