
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

public class PotionUpdate : MonoBehaviour
{
    public event Action<string> OnRecipeCompleted;

    private const string TutorialID = "potion_01";
    private const string SolidRockID = "potion_02";
    private const string IsaacID = "potion_03";
    private const string GamajoID = "potion_04";

    int demonIndexList;

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

    private IEnumerator ResetPotion()
    {
        yield return new WaitForSeconds(2f);

        ingredientsAdded.Clear();

        if (potionVisuals != null)
            potionVisuals.ResetPotionVisuals();

        Debug.Log("Potion réinitialisée.");
    }

    private void CompleteRecipe(string completedRecipeID, int demonIndex, bool isTutorial = false)
    {
        Debug.Log("Recette réussie ! ID envoyé : " + completedRecipeID);

        OnRecipeCompleted?.Invoke(completedRecipeID);

        demonIndex = demonIndexList;

        PotionSuccess = true;
        Summon.GetComponent<Summon>().CheckSumonning();
        Summon.GetComponent<Summon>().SelectDemon = demonIndex;
        Summon.GetComponent<Summon>().AlreadySummon = false;

        if (isTutorial)
            FinishTuto = true;

        if (potionVisuals != null && potionVisuals.water != null)
            potionVisuals.water.position = transform.parent.position;

        StartCoroutine(ResetPotion());
    }

    private void CheckRecipe()
    {
        Recipe recipe = Recipe.GetComponent<Recipe>();

        if (!FinishTuto)
        {
            if (ingredientsAdded.Count > recipe.recipeIngredientsTuto.Count)
            {
                Debug.Log("Recette incorrecte : trop d'ingrédients !");
                StartCoroutine(ResetPotion());
                return;
            }

            for (int i = 0; i < ingredientsAdded.Count; i++)
            {
                if (ingredientsAdded[i] != recipe.recipeIngredientsTuto[i])
                {
                    Debug.Log("Recette incorrecte !");
                    StartCoroutine(ResetPotion());
                    return;
                }
            }

            if (ingredientsAdded.Count == recipe.recipeIngredientsTuto.Count)
            {
                demonIndexList = 0;
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
                    StartCoroutine(ResetPotion());
                    return;
                }

                for (int i = 0; i < ingredientsAdded.Count; i++)
                {
                    if (ingredientsAdded[i] != recipe.recipeIngredientssolidrock[i])
                    {
                        Debug.Log("Recette incorrecte ! SolidRock");
                        StartCoroutine(ResetPotion());
                        return;
                    }
                }

                if (ingredientsAdded.Count == recipe.recipeIngredientssolidrock.Count)
                {
                    demonIndexList = 1;
                    CompleteRecipe(SolidRockID, 1);
                    
                }
                    
                    
                
                else
                    Debug.Log("Recette en cours...");
            }
            else if (recipe.recipeIngredientsisaac[j] == IngredientType.DragonBlood && ingredientsAdded[j] == IngredientType.DragonBlood)
            {
                if (ingredientsAdded.Count > recipe.recipeIngredientsisaac.Count)
                {
                    Debug.Log("Recette incorrecte : trop d'ingrédients !");
                    StartCoroutine(ResetPotion());
                    return;
                }

                for (int i = 0; i < ingredientsAdded.Count; i++)
                {
                    if (ingredientsAdded[i] != recipe.recipeIngredientsisaac[i])
                    {
                        Debug.Log("Recette incorrecte ! Isaac");
                        StartCoroutine(ResetPotion());
                        return;
                    }
                }

                if (ingredientsAdded.Count == recipe.recipeIngredientsisaac.Count)
                {
                    demonIndexList = 2;
                    CompleteRecipe(IsaacID, 2);
                    
                }
                else
                    Debug.Log("Recette en cours...");
            }
            else if (recipe.recipeIngredientsGamajo[j] == IngredientType.Eye && ingredientsAdded[j] == IngredientType.Eye)
            {
                if (ingredientsAdded.Count > recipe.recipeIngredientsGamajo.Count)
                {
                    Debug.Log("Recette incorrecte : trop d'ingrédients !");
                    StartCoroutine(ResetPotion());
                    return;
                }

                for (int i = 0; i < ingredientsAdded.Count; i++)
                {
                    if (ingredientsAdded[i] != recipe.recipeIngredientsGamajo[i])
                    {
                        Debug.Log("Recette incorrecte ! Gamajo");
                        StartCoroutine(ResetPotion());
                        return;
                    }
                }

                if (ingredientsAdded.Count == recipe.recipeIngredientsGamajo.Count)
                {
                    demonIndexList = 3;
                    CompleteRecipe(GamajoID, 3);

                }
                else
                    Debug.Log("Recette en cours...");
            }
            else
            {
                Debug.Log("Recette incorrecte : mauvais premier ingrédient !");
                StartCoroutine(ResetPotion());
            }
        }
    }
}
