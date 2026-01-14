using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void LoadScenePlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    void GameExit()
    {
        Application.Quit();
    }
}
