using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelmanager : MonoBehaviour
{
   public static Levelmanager Instance { get; private set;}

    public GameObject CharacterPrefab;


    private void Awake()
    {
        Instance = this;
        Instantiate(CharacterPrefab, transform.position, Quaternion.identity);
    }

    public void NextCharacter()
    {
        Instantiate(CharacterPrefab, transform.position, Quaternion.identity);
    }
}
