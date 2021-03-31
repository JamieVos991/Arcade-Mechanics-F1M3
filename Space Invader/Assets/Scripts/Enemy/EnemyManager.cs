using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private const float START_Y = 4f;

    private bool entering = true;

    public static List<GameObject> allAliens = new List<GameObject>();

    void Update()
    {
        if (entering)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 10);

            if(transform.position.y <= START_Y)
            {
                entering = false; 
            }
        }
    }
}
