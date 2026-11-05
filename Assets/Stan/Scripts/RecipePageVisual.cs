using UnityEngine;

public class RecipePageVisual : MonoBehaviour
{
    [Header("Recipe")]
    [SerializeField] private string recipeID;

    [Header("Appearance")]
    [SerializeField] private Renderer pageRenderer;

    public string RecipeID => recipeID;

    private void Awake()
    {
        if (pageRenderer == null)
            pageRenderer = GetComponent<Renderer>();

        pageRenderer.enabled = false;
    }

    public void Reveal()
    {
        pageRenderer.enabled = true;
        Debug.Log("Apparition de la page : " + recipeID);
    }
}