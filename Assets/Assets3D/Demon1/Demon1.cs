using UnityEngine;
using System.Collections;


public class Demon1 : MonoBehaviour
{
    public AudioSource Audio;
    public GameObject[] Recipe;
    public Vector3[] RecipeLocation;

    public float targetTime = 0f;

    private void Start()
    {
        Audio.Play();
        targetTime = Audio.clip.length;
    }

    void Update()
    {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        for (int i = 0; i < Recipe.Length; i++)
        {
            var demon = Instantiate(Recipe[i],RecipeLocation[i], new Quaternion());
            demon.transform.localScale = new Vector3(0.5f,0.5f,0.005f);
        }
        Destroy(gameObject);
    }
}
