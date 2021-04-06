using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public ShipStats shipStats;

    public GameObject bulletPrefab;

    private Vector2 offScreenPos = new Vector2(0, -20);
    private Vector2 startPos = new Vector2(0, -6);

    private const float max_left = -12.5f;
    private const float max_right = 12.5f;

    private bool isShooting; 

    //AudioSource BulletShot;

    private void Start()
    {
        //BulletShot = GetComponent<AudioSource>();

        transform.position = startPos;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > max_left)
        {
            transform.Translate(Vector2.left * Time.deltaTime * shipStats.shipSpeed);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < max_right)
        {
            transform.Translate(Vector2.right * Time.deltaTime * shipStats.shipSpeed);
        }
        
        if (Input.GetKey(KeyCode.Space) && !isShooting)
        {
            //BulletShot.Play();
            StartCoroutine(Shoot());
        }
    }

    private void TakeDamage()
    {

        if (shipStats.currentHealth <= 0)
        {
            Debug.Log("Game Over!");
            //Game Over
        }
        else
        {
            StartCoroutine(Respawn());
        }
    }


    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(shipStats.fireRate);
        isShooting = false;
    }

    private IEnumerator Respawn()
    {
        transform.position = offScreenPos;

        yield return new WaitForSeconds(2);

        shipStats.currentHealth = shipStats.maxHealth;

        transform.position = startPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("Player Hit");
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}