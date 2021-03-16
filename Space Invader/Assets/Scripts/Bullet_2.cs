using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_2 : MonoBehaviour
{

    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
