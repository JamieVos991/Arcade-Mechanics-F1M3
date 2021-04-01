﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public ShipStats shipStats;

    public GameObject bulletPrefab;

    private const float max_left = -12.5f;
    private const float max_right = 12.5f;

    private bool isShooting; 

    private void Start()
    {
        shipStats.currentHealth = shipStats.maxHealth;
        shipStats.currentLives = shipStats.maxLives; 
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
            StartCoroutine(Shoot());
        }
    }

    private void TakeDamage()
    {
        shipStats.currentHealth--;

        if (shipStats.currentHealth <= 0)
        {
            shipStats.currentLives--; 

            if(shipStats.currentLives <= 0)
            {
                Debug.Log("Game Over!");
                //Game Over
            }
            else
            {
                Debug.Log("Respawning...");
                //Respawn
            }
        }
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(shipStats.fireRate);
        isShooting = false;
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