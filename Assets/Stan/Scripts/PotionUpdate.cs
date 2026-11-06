
using System.Collections.Generic;
using UnityEngine;
using System;

public class PotionUpdate : MonoBehaviour
{
    public event Action<string> OnRecipeCompleted;

    private const string TutorialID = "potion_01";
    private const string SolidRockID = "potion_02";
    private const string IsaacID = "potion_03";
    private const string GamajoID = "potion_04";

    [Header("Potion")]
    [SerializeField] private PotionVisuals potionVisuals;

    [Header("Recipe")]
    [SerializeField] public GameObject Recipe;

    [Header("Ingredients Added")]
    [SerializeField] private List<IngredientType> ingredientsAdded = new List<IngredientType>();
    [SerializeField] private GameObject Summon;

    public bool PotionSuccess = false;
    public bool FinishTuto = false;

    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PotionIngredient ingredient = other.GetComponentInParent<PotionIngredient>();

        if (ingredient == null)
            return;

        ingredientsAdded.Add(ingredient.ingredientType);

        if (potionVisuals != null)
            potionVisuals.UpdatePotionVisuals(ingredient.GetIngredientMaterial());

        other.GetComponent<Rigidbody>().isKinematic = false;
        other.GetComponent<Rigidbody>().useGravity = true;
        audioSource.Play();

        Instantiate(ingredient.gameObject, other.GetComponent<Respawn>().SpawnLocation, other.transform.rotation);

        ParticleSystem particles = ingredient.GetComponentInChildren<ParticleSystem>();

        if (particles != null)
        {
            Quaternion particlesRotation = particles.transform.rotation;
            particles.transform.SetParent(null);
            particles.transform.rotation = particlesRotation;
            Debug.Log("Splash");
            particles.Play();
            Destroy(particles.gameObject, particles.main.duration + particles.main.startLifetime.constantMax);
        }

        Destroy(ingredient.gameObject);

        CheckRecipe();
    }

    private void CompleteRecipe(string completedRecipeID, int demonIndex, bool isTutorial = false)
    {
        Debug.Log("Recette réussie ! ID envoyé : " + completedRecipeID);

        OnRecipeCompleted?.Invoke(completedRecipeID);

        PotionSuccess = true;
        Summon.GetComponent<Summon>().CheckSumonning();
        Summon.GetComponent<Summon>().SelectDemon = demonIndex;

        if (isTutorial)
            FinishTuto = true;

        potionVisuals.water.position = transform.parent.position;
        ingredientsAdded = new List<IngredientType>();
    }

    private void CheckRecipe()
    {
        Recipe recipe = Recipe.GetComponent<Recipe>();

        if (!FinishTuto)
        {
            if (ingredientsAdded.Count > recipe.recipeIngredientsTuto.Count)
            {
                Debug.Log("Recette incorrecte : trop d'ingrédients !");
                return;
            }

            for (int i = 0; i < ingredientsAdded.Count; i++)
            {
                if (ingredientsAdded[i] != recipe.recipeIngredientsTuto[i])
                {
                    Debug.Log("Recette incorrecte !");
                    return;
                }
            }

            if (ingredientsAdded.Count == recipe.recipeIngredientsTuto.Count)
            {
                CompleteRecipe(TutorialID, 0, true);
            }
            else
            {
                Debug.Log("Recette en cours...");
            }
        }
        else
        {
            int j = 0;

            if (recipe.recipeIngredientssolidrock[j] == IngredientType.Toad && ingredientsAdded[j] == IngredientType.Toad)
            {
                if (ingredientsAdded.Count > recipe.recipeIngredientssolidrock.Count)
                {
                    Debug.Log("Recette incorrecte : trop d'ingrédients !");
                    return;
                }

                for (int i = 0; i < ingredientsAdded.Count; i++)
                {
                    if (ingredientsAdded[i] != recipe.recipeIngredientssolidrock[i])
                    {
                        Debug.Log("Recette incorrecte ! SolidRock");
                        return;
                    }
                }

                if (ingredientsAdded.Count == recipe.recipeIngredientssolidrock.Count)
                    CompleteRecipe(SolidRockID, 1);
                else
                    Debug.Log("Recette en cours...");
            }
            else if (recipe.recipeIngredientsisaac[j] == IngredientType.DragonBlood && ingredientsAdded[j] == IngredientType.DragonBlood)
            {
                if (ingredientsAdded.Count > recipe.recipeIngredientsisaac.Count)
                {
                    Debug.Log("Recette incorrecte : trop d'ingrédients !");
                    return;
                }

                for (int i = 0; i < ingredientsAdded.Count; i++)
                {
                    if (ingredientsAdded[i] != recipe.recipeIngredientsisaac[i])
                    {
                        Debug.Log("Recette incorrecte ! Isaac");
                        return;
                    }
                }

                if (ingredientsAdded.Count == recipe.recipeIngredientsisaac.Count)
                    CompleteRecipe(IsaacID, 2);
                else
                    Debug.Log("Recette en cours...");
            }
            else if (recipe.recipeIngredientsGamajo[j] == IngredientType.Eye && ingredientsAdded[j] == IngredientType.Eye)
            {
                if (ingredientsAdded.Count > recipe.recipeIngredientsGamajo.Count)
                {
                    Debug.Log("Recette incorrecte : trop d'ingrédients !");
                    return;
                }

                for (int i = 0; i < ingredientsAdded.Count; i++)
                {
                    if (ingredientsAdded[i] != recipe.recipeIngredientsGamajo[i])
                    {
                        Debug.Log("Recette incorrecte ! Gamajo");
                        return;
                    }
                }

                if (ingredientsAdded.Count == recipe.recipeIngredientsGamajo.Count)
                    CompleteRecipe(GamajoID, 3);
                else
                    Debug.Log("Recette en cours...");
            }
        }
    }
}
