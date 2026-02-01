using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScreen : MonoBehaviour
{
    public void loadgame()
    {
        SceneManager.LoadScene("firstPuzzle");
    }

    public void exitgame()
    {
        Application.Quit();
    }
}
