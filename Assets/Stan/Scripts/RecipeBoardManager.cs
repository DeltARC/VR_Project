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
        if (potionUpdate != null)
            potionUpdate.OnRecipeCompleted += DiscoverRecipe;
    }

    private void OnDisable()
    {
        if (potionUpdate != null)
            potionUpdate.OnRecipeCompleted -= DiscoverRecipe;
    }

    private void DiscoverRecipe(string recipeID)
    {
        if (discoveredRecipes.Contains(recipeID))
            return;

        discoveredRecipes.Add(recipeID);

        foreach (RecipePageVisual page in recipePages)
        {
            if (page.RecipeID == recipeID)
            {
                page.Reveal();
                return;
            }
        }
    }
}