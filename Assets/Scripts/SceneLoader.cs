using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentSceneIndex);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        GameSession Status1 = FindObjectOfType<GameSession>();
        Status1.Reset();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
