using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        // Reset stats in GameManager
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
