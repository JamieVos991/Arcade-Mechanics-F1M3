using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectile : MonoBehaviour
{
    public GameObject BulletPrefab;

    public int bullet_amount = 100;
    public TextMeshProUGUI bullet_value_textholder; 

  

    void Update()
    {
        bullet_value_textholder.text = bullet_amount.ToString();
    }

    
    public void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, this.transform.position, transform.rotation, transform);
        bullet_amount--;

        Destroy(bullet, 1.5f);
    }
}
