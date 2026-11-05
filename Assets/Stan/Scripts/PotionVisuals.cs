using UnityEngine;

public class PotionVisuals : MonoBehaviour
{
    [Header("Water")]
    [SerializeField] private Transform water;
    [SerializeField] private Renderer waterRenderer;

    [Header("Feedback")]
    [SerializeField] private float heightIncrease = 0.03f;
    [SerializeField] private Color potionColor = Color.green;

    public void UpdatePotionVisuals()
    {
        water.localPosition += Vector3.up * heightIncrease;
        waterRenderer.material.color = potionColor;
    }
}