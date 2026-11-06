using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Script lier à == UI == dans la scene MainMenu
    [SerializeField] private AudioClip buttonPressedSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButton()
    {
        //play sound
        //audioSource.clip = buttonPressedSound;
        //audioSource.Play();

        SceneManager.LoadScene("BasicScene");
    }

    public void OptionButton()
    {
        //play sound
        audioSource.clip = buttonPressedSound;
        audioSource.Play();
    }

    public void Highlight()
    {

    }

}
