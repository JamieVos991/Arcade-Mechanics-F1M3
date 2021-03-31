using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public GameObject bulletPrefab;

    private const float max_left = -12.5f;
    private const float max_right = 12.5f;

    private float speed = 9;
    private float cooldown = 0.5f;

    private bool isShooting; 

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > max_left)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < max_right)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        
        if (Input.GetKey(KeyCode.Space) && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }
    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(cooldown);
        isShooting = false;
    }
}