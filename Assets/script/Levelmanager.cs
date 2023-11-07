using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelmanager : MonoBehaviour
{
   public static Levelmanager Instance { get; private set;}

    public GameObject CharacterPrefab;

    public GameObject ClearDilog;

    public int EnemyCount { get; private set; } = 0;

    private void Awake()
    {
        Instance = this;
        Instantiate(CharacterPrefab, transform.position, Quaternion.identity);
    }

    public void NextCharacter()
    {
        Instantiate(CharacterPrefab, transform.position, Quaternion.identity);
    }
    public void EnemyCountAdd()
    {
        EnemyCount++;
    }

    public void EnemyDie()
    {
        EnemyCount--;
        {
            if(EnemyCount ==0)
            {
                ClearDilog.SetActive(true);
            }
        }
    }

}
