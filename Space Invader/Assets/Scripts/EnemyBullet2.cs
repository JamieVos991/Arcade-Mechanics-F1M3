using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
{

    private float speed = 10;

    void Update()
    {
        
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
}

