using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float DieVelocity = 5;
    //   is called before the first frame update
    void Start()
    {
        Levelmanager.Instance.EnemyCountAdd();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.sqrMagnitude>DieVelocity)
        {
            Destroy(gameObject);
            Levelmanager.Instance.EnemyDie();
        }
       
    }
}
