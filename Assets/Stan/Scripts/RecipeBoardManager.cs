using System.Collections.Generic;
using UnityEngine;

public class RecipeBoardManager : MonoBehaviour
{
    [Header("Potion")]
    [SerializeField] private PotionUpdate potionUpdate;

    [Header("Pages")]
    [SerializeField] private List<RecipePageVisual> recipePages = new List<RecipePageVisual>();

    private List<string> discoveredRecipes = new List<string>();

    private void OnEnable()
    {
        potionUpdate.OnRecipeCompleted += DiscoverRecipe;
    }

    private void OnDisable()
    {
        potionUpdate.OnRecipeCompleted -= DiscoverRecipe;
    }

    private void DiscoverRecipe(string completedRecipeID)
    {
        foreach (RecipePageVisual page in recipePages)
        {
            if (page.RecipeID == completedRecipeID)
            {
                page.Reveal();
                return;
            }
        }

        Debug.LogWarning("Recette introuvable sur le tableau : " + completedRecipeID);
    }
}