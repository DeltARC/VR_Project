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
        Debug.Log("[RecipeBoardManager] OnEnable appelé.");

        if (potionUpdate != null)
        {
            potionUpdate.OnRecipeCompleted += DiscoverRecipe;
            Debug.Log("[RecipeBoardManager] Abonnement à PotionUpdate réussi.");
        }
        else
        {
            Debug.LogError("[RecipeBoardManager] PotionUpdate n'est pas assigné !");
        }
    }

    private void OnDisable()
    {
        if (potionUpdate != null)
            potionUpdate.OnRecipeCompleted -= DiscoverRecipe;
    }

    private void DiscoverRecipe(string recipeID)
    {
        Debug.Log("[RecipeBoardManager] Événement reçu ! ID : " + recipeID);

        if (discoveredRecipes.Contains(recipeID))
        {
            Debug.Log("[RecipeBoardManager] Recette déjà découverte.");
            return;
        }

        discoveredRecipes.Add(recipeID);

        Debug.Log("[RecipeBoardManager] Recherche de la page correspondante.");

        foreach (RecipePageVisual page in recipePages)
        {
            Debug.Log("[RecipeBoardManager] Page trouvée dans la liste : " + page.RecipeID);

            if (page.RecipeID == recipeID)
            {
                Debug.Log("[RecipeBoardManager] Correspondance trouvée ! Appel de Reveal().");
                page.Reveal();
                return;
            }
        }

        Debug.LogWarning("[RecipeBoardManager] Aucune page trouvée pour : " + recipeID);
    }
}