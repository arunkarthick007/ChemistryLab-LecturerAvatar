using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}