using UnityEngine;

[System.Serializable]

public class ShipStats
{
    [Range(1,5)]
    public int maxHealth;
    [HideInInspector]
    public int currentHealth = 3;
    [HideInInspector]
    public int maxLives = 3;
    [HideInInspector]

    public float shipSpeed;
    public float fireRate = 0.05f;
}
