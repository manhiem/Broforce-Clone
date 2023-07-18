using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject characterSlider;
    [SerializeField]
    private Text killedEnemies;

    private void Start()
    {
        if (PlayerPrefs.HasKey("KilledEnemies"))
        {
            killedEnemies.text = "Enemies Killed: " + PlayerPrefs.GetInt("KilledEnemies", 0).ToString();
        }
        else
        {
            killedEnemies.text = "Enemies Killed: 0";
        }
    }

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
