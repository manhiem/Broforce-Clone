using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject characterSlider;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void DisplayCharacters()
    {
        characterSlider.SetActive(true);
    }

    public void CloseSlider()
    {
        characterSlider.SetActive(false);
    }
}
