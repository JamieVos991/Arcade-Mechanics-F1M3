using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
            Debug.Log("HIT");
            Destroy(other.gameObject);
            this.gameObject.SetActive(false);
            Destroy(gameObject);
        
    }
}