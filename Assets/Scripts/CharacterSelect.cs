using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] characters;
    private int selectedCharacter = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject ch in characters)
        {
            ch.SetActive(false);
        }

        characters[selectedCharacter].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCharacter(int newChar)
    {
        characters[selectedCharacter].SetActive(false);
        characters[newChar].SetActive(true);

        selectedCharacter = newChar;
    }
}
