using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScreen : MonoBehaviour
{
    public void loadgame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void exitgame()
    {
        Application.Quit();
    }
}
