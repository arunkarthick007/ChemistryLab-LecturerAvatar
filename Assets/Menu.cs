using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
