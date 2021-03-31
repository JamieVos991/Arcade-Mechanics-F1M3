using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoScript : MonoBehaviour
{
    public int scoreValue;

    private const float max_left = -17.5f;
    private float speed = 15;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if(transform.position.x <= max_left)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
