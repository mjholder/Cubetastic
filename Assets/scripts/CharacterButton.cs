using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    /* Character indexes:
        O: Cube
        1: Man
        2: Corgi
    */
    public int characterIndex;

    public void SetCharacter()
    {
        PlayerPrefs.SetInt("Character", characterIndex);
    }
}
