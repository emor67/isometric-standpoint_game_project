using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Final");
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
