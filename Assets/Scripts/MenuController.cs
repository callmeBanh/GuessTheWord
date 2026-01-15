using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
      
        SceneManager.LoadScene("GamePlay");
    }
    public void BackToMenu()
    {
       
        SceneManager.LoadScene("StartGame");
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void NextLevel()
    {   
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);      
        currentLevel++;       
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.Save(); 

        Debug.Log("Đã chuyển sang Level: " + currentLevel);

        SceneManager.LoadScene("GamePlay");
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        
        Debug.Log("Đã bấm nút thoát game!");
    }
}
