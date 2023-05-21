using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("developmentScene");
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
