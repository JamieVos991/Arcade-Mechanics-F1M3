using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.up * speed;
    }
}
