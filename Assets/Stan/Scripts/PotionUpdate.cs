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

    [SerializeField] public GameObject Recipe;

    [SerializeField] private string[] NameRecipe = { "recipeIngredientsTuto", "recipeIngredientssolidrock", "recipeIngredientsisaac", "recipeIngredientsGamajo" };

    [Header("Ingredients Added")]
    [SerializeField] private List<IngredientType> ingredientsAdded = new List<IngredientType>();
    [SerializeField] private GameObject Summon;

    public bool PotionSuccess = false;

    public bool FinishTuto = false;

    private void OnTriggerEnter(Collider other)
    {
        PotionIngredient ingredient = other.GetComponentInParent<PotionIngredient>();

        if (ingredient == null)
            return;

        ingredientsAdded.Add(ingredient.ingredientType);

        if (potionVisuals != null)
            potionVisuals.UpdatePotionVisuals(ingredient.GetIngredientMaterial());

        other.GetComponent<Respawn>().Respawning();

        CheckRecipe();
    }

    private void CheckRecipe()
    {
        if(!FinishTuto)
        {
            if (ingredientsAdded.Count > Recipe.GetComponent<Recipe>().recipeIngredientsTuto.Count)// Tuto
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
                FinishTuto = true;
                potionVisuals.water.position = gameObject.GetComponentInParent<Transform>().position;
                ingredientsAdded = new List<IngredientType>();
            }
            else
            {
                Debug.Log("Recette en cours...");
            }
        }
        else
        {
            int j = 0;

            if (Recipe.GetComponent<Recipe>().recipeIngredientssolidrock[j] == IngredientType.Toad && ingredientsAdded[j] == IngredientType.Toad) //SolidRock
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
                        Debug.Log("Recette incorrecte ! SolidRock");
                        return;
                    }
                }

                if (ingredientsAdded.Count == Recipe.GetComponent<Recipe>().recipeIngredientssolidrock.Count)
                {
                    Debug.Log("Recette réussie ! SolidRock");
                    OnRecipeCompleted?.Invoke(recipeID);
                    PotionSuccess = true;
                    Summon.GetComponent<Summon>().CheckSumonning();
                    potionVisuals.water.position = gameObject.GetComponentInParent<Transform>().position;
                    ingredientsAdded = new List<IngredientType>();
                }
                else
                {
                    Debug.Log("Recette en cours...");
                }
            }
            else if(Recipe.GetComponent<Recipe>().recipeIngredientsisaac[j] == IngredientType.DragonBlood && ingredientsAdded[j] == IngredientType.DragonBlood) // Issac
            {
                if (ingredientsAdded.Count > Recipe.GetComponent<Recipe>().recipeIngredientsisaac.Count)
                {
                    Debug.Log("Recette incorrecte : trop d'ingrédients !");
                    return;
                }

                for (int i = 0; i < ingredientsAdded.Count; i++)
                {
                    if (ingredientsAdded[i] != Recipe.GetComponent<Recipe>().recipeIngredientsisaac[i])
                    {
                        Debug.Log("Recette incorrecte ! Issac");
                        return;
                    }
                }

                if (ingredientsAdded.Count == Recipe.GetComponent<Recipe>().recipeIngredientsisaac.Count)
                {
                    Debug.Log("Recette réussie ! Issac");
                    OnRecipeCompleted?.Invoke(recipeID);
                    PotionSuccess = true;
                    Summon.GetComponent<Summon>().CheckSumonning();
                    potionVisuals.water.position = gameObject.GetComponentInParent<Transform>().position;
                    ingredientsAdded = new List<IngredientType>();
                }
                else
                {
                    Debug.Log("Recette en cours...");
                }
            }
            else if(Recipe.GetComponent<Recipe>().recipeIngredientsGamajo[j] == IngredientType.Eye && ingredientsAdded[j] == IngredientType.Eye) //Gamajo
            {
                if (ingredientsAdded.Count > Recipe.GetComponent<Recipe>().recipeIngredientsGamajo.Count)
                {
                    Debug.Log("Recette incorrecte : trop d'ingrédients !");
                    return;
                }

                for (int i = 0; i < ingredientsAdded.Count; i++)
                {
                    if (ingredientsAdded[i] != Recipe.GetComponent<Recipe>().recipeIngredientsGamajo[i])
                    {
                        Debug.Log("Recette incorrecte ! Gamajo");
                        return;
                    }
                }

                if (ingredientsAdded.Count == Recipe.GetComponent<Recipe>().recipeIngredientsGamajo.Count)
                {
                    Debug.Log("Recette réussie ! Gamajo");
                    OnRecipeCompleted?.Invoke(recipeID);
                    PotionSuccess = true;
                    Summon.GetComponent<Summon>().CheckSumonning();
                    potionVisuals.water.position = gameObject.GetComponentInParent<Transform>().position;
                    ingredientsAdded = new List<IngredientType>();
                }
                else
                {
                    Debug.Log("Recette en cours...");
                }
            }
        }
        
    }
}