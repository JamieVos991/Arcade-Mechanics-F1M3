using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : MonoBehaviour
{

    public GameObject MothershipPrefab;
    public int scoreValue;

    private Vector3 MotherShipSpawnPos = new Vector3(19.11f, 4f, 0);

    private const float moveTimer = 0.01f; 
    private const float MAX_LEFT = -5f; 
    private float speed = 5;
    private float mothershipTimer = 60f;
    private const float MOTHERSHIP_MIN = 15f;
    private const float MOTHERSHIP_MAX = 60;
    private float shootTimer = 3f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (transform.position.x <= MAX_LEFT)
        {
            Destroy(gameObject);
        }

        if (mothershipTimer <= 0)
        {
            SpawnMothership();
        }

        
        shootTimer -= Time.deltaTime;
        mothershipTimer -= Time.deltaTime;

    }

    private void SpawnMothership()
    {
        Instantiate(MothershipPrefab, MotherShipSpawnPos, Quaternion.identity);
        mothershipTimer = Random.Range(MOTHERSHIP_MIN, MOTHERSHIP_MAX);
    }
}
