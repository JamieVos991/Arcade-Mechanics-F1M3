using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Player;
    public GameObject projectile;
    public GameObject projectileClone;
    public int speed = 5;

    void Start()
    {

    }

    // Start is called before the first frame update
    void Update()
    {
        movement();
        fireProjectile();
    }

    // Update is called once per frame
    void movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0f, 0f));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));
        }

    }
    
    void fireProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            projectileClone = Instantiate(fireProjectile, new Vector3(0, 0, 0), transform.rotation) as GameObject;
        }
    }
}
