using System.Collections;
using UnityEngine;

public class RecipePageVisual : MonoBehaviour
{
    [Header("Recipe")]
    [SerializeField] private string recipeID;

    [Header("Page")]
    [SerializeField] private Renderer pageRenderer;

    [Header("Animation")]
    [SerializeField] private float animationDuration = 2.5f;
    [SerializeField] private float maxParticleRadius = 7.07f;

    [Header("Particles")]
    [SerializeField] private ParticleSystem appearanceParticles;

    private MaterialPropertyBlock propertyBlock;
    private Coroutine appearanceCoroutine;
    private bool isRevealed;

    private static readonly int RevealProgressID = Shader.PropertyToID("_RevealProgress");

    public string RecipeID => recipeID;

    private void Awake()
    {
        if (pageRenderer == null)
            pageRenderer = GetComponent<Renderer>();

        propertyBlock = new MaterialPropertyBlock();

        SetRevealProgress(0f);
        pageRenderer.enabled = false;
    }

    public void Reveal()
    {
        if (isRevealed || appearanceCoroutine != null)
            return;

        isRevealed = true;
        pageRenderer.enabled = true;

        if (appearanceParticles != null)
        {
            appearanceParticles.Clear();
            appearanceParticles.Play();
        }

        appearanceCoroutine = StartCoroutine(AnimateAppearance());
    }

    private IEnumerator AnimateAppearance()
    {
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;

            float progress = Mathf.Clamp01(elapsedTime / animationDuration);
            float smoothProgress = progress * progress * (3f - 2f * progress);

            SetRevealProgress(smoothProgress);
            UpdateParticleRadius(smoothProgress);

            yield return null;
        }

        SetRevealProgress(1f);

        if (appearanceParticles != null)
            appearanceParticles.Stop(false, ParticleSystemStopBehavior.StopEmitting);

        appearanceCoroutine = null;
    }

    private void SetRevealProgress(float progress)
    {
        pageRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetFloat(RevealProgressID, progress);
        pageRenderer.SetPropertyBlock(propertyBlock);
    }

    private void UpdateParticleRadius(float progress)
    {
        if (appearanceParticles == null)
            return;

        ParticleSystem.ShapeModule shape = appearanceParticles.shape;
        shape.radius = Mathf.Lerp(0.05f, maxParticleRadius, progress);
    }
}