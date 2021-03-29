using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public GameObject bulletPrefab;

    public static List<GameObject> allAliens = new List<GameObject>();

    private float shootTimer = 1f;
    private const float shootTime = 1f;

    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Alien"))
            allAliens.Add(go);
    }


    void Update()
    {
        if (shootTimer <= 0)
        {
            Shoot();
        }

        shootTimer -= Time.deltaTime;
    }

    private void Shoot()
    {
        Vector2 pos = allAliens[Random.Range(0, allAliens.Count)].transform.position;

        Instantiate(bulletPrefab, pos, Quaternion.identity);

        shootTimer = shootTime;

    }
}