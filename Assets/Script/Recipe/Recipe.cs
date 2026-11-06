using System.Collections.Generic;
using UnityEngine;

public class Recipe: MonoBehaviour
{
    [SerializeField] public List<IngredientType> recipeIngredientsTuto = new List<IngredientType>();
    [SerializeField] public List<IngredientType> recipeIngredientssolidrock = new List<IngredientType>();
    [SerializeField] public List<IngredientType> recipeIngredientsisaac = new List<IngredientType>();
    [SerializeField] public List<IngredientType> recipeIngredientsGamajo = new List<IngredientType>();

}
