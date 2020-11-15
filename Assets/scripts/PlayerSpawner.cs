using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Character[] characters;
    private Character character;

    // Start is called before the first frame update
    void Start()
    {
        character = characters[PlayerPrefs.GetInt("Character")];
        InstantiatePrefab();
    }

    void InstantiatePrefab()
    {
        Instantiate(character.prefab, this.transform);
    }
}
