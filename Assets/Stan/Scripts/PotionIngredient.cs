using UnityEngine;

public class PotionIngredient : MonoBehaviour
{
    public IngredientType ingredientType;
    [SerializeField] private Material ingredientMaterial;

    public Material GetIngredientMaterial()
    {
        return ingredientMaterial;
    }
}

public enum IngredientType
{ 
    Eye, Bat, Toad, Venom, Mandragora, DragonBlood
}