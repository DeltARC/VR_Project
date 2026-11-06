using UnityEngine;
using System.Collections;


public class Demon2 : MonoBehaviour
{
    public AudioSource Audio;

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
        Destroy(gameObject);
    }
}
