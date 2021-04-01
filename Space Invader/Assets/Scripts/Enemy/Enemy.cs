using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scoreValue;

    //public GameObject explosion; 

    public void Kill()
    {
        EnemyInput.allAliens.Remove(gameObject);

        //Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(gameObject);

        Debug.Log("HIT");
    }
}
