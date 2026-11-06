using System.Collections.Generic;
using UnityEngine;
using System;

public class PotionUpdate : MonoBehaviour
{
    public event Action<string> OnRecipeCompleted;
    [SerializeField] private string recipeID;

    [Header("Potion")]
    [SerializeField] private PotionVisuals potionVisuals;

    [Header("Recipe")]
    [SerializeField] private List<IngredientType> recipeIngredients = new List<IngredientType>();
    [SerializeField] public GameObject Recipe;

    [Header("Ingredients Added")]
    [SerializeField] private List<IngredientType> ingredientsAdded = new List<IngredientType>();
    [SerializeField] private GameObject Summon;

    public bool PotionSuccess = false;

    private bool FinishTuto = false;

    private void OnTriggerEnter(Collider other)
    {
        PotionIngredient ingredient = other.GetComponentInParent<PotionIngredient>();

        if (ingredient == null)
            return;

        ingredientsAdded.Add(ingredient.ingredientType);

        if (potionVisuals != null)
            potionVisuals.UpdatePotionVisuals(ingredient.GetIngredientMaterial());

        Destroy(ingredient.gameObject);

        CheckRecipe();
    }

    private void CheckRecipe()
    {
        if(!FinishTuto)
        {
            if (ingredientsAdded.Count > Recipe.GetComponent<Recipe>().recipeIngredientsTuto.Count)
            {
                Debug.Log("Recette incorrecte : trop d'ingrédients !");
                return;
            }

            for (int i = 0; i < ingredientsAdded.Count; i++)
            {
                if (ingredientsAdded[i] != Recipe.GetComponent<Recipe>().recipeIngredientsTuto[i])
                {
                    Debug.Log("Recette incorrecte !");
                    return;
                }
            }

            if (ingredientsAdded.Count == Recipe.GetComponent<Recipe>().recipeIngredientsTuto.Count)
            {
                Debug.Log("Recette réussie !");
                OnRecipeCompleted?.Invoke(recipeID);
                PotionSuccess = true;
                Summon.GetComponent<Summon>().CheckSumonning();
            }
            else
            {
                Debug.Log("Recette en cours...");
            }
        }
        else
        {
            if (ingredientsAdded.Count > Recipe.GetComponent<Recipe>().recipeIngredientssolidrock.Count)
            {
                Debug.Log("Recette incorrecte : trop d'ingrédients !");
                return;
            }

            for (int i = 0; i < ingredientsAdded.Count; i++)
            {
                if (ingredientsAdded[i] != Recipe.GetComponent<Recipe>().recipeIngredientssolidrock[i])
                {
                    Debug.Log("Recette incorrecte !");
                    return;
                }
            }

            if (ingredientsAdded.Count == Recipe.GetComponent<Recipe>().recipeIngredientssolidrock.Count)
            {
                Debug.Log("Recette réussie !");
                OnRecipeCompleted?.Invoke(recipeID);
                PotionSuccess = true;
                Summon.GetComponent<Summon>().CheckSumonning();
            }
            else
            {
                Debug.Log("Recette en cours...");
            }
        }
        
    }
}