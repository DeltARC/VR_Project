using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Script lier à == UI == dans la scene MainMenu
    public void PlayButton()
    {
        SceneManager.LoadScene("BasicScene");
    }

    public void OptionButton()
    {
        // Rend le menu invislbe et passe les option visible.
        //OptionPanel.SetActive(true);
    }

}
