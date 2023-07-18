using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public GameObject[] charactersList;
    private int index = 0;

    private void Start()
    {
        ShowCharacter();
    }

    private void ShowCharacter()
    {
        for (int i = 0; i < charactersList.Length; i++)
        {
            charactersList[i].SetActive(i == index);
        }
    }

    public void Next()
    {
        index = (index + 1) % charactersList.Length;
        ShowCharacter();
    }

    public void Previous()
    {
        index = (index - 1 + charactersList.Length) % charactersList.Length;
        ShowCharacter();
    }
}
