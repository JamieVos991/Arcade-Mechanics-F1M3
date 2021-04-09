using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public int life = 3;

    public GameObject bulletPrefab;

    private Vector2 offScreenPos = new Vector2(0, -20);
    private Vector2 startPos = new Vector2(0, -6);

    private const float max_left = -12.5f;
    private const float max_right = 12.5f;

    private bool isShooting;


    private void Start()
    {
        transform.position = startPos;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > max_left)
        {
            transform.Translate(Vector2.left * Time.deltaTime * 9f);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < max_right)
        {
            transform.Translate(Vector2.right * Time.deltaTime * 9f);
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
        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }

    /*public IEnumerator Respawn()
    {
        transform.position = offScreenPos;

        yield return new WaitForSeconds(2);

        transform.position = startPos;
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("Player Hit");
            Destroy(collision.gameObject);

            life -= 1;
            if (life == 0)
            {
                MenuManager.OpenGameOver();
            }
        }
    }
}