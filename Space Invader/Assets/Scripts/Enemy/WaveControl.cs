using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControl : MonoBehaviour
{
    public GameObject[] allAliensSets;

    private GameObject currentSet;
    private Vector2 spawnPos = new Vector2(0, 10);

    private static WaveControl instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnNewWave();
    }

    public static void SpawnNewWave()
    {
        instance.StartCoroutine(instance.SpawnWave());
       
    }

    private IEnumerator SpawnWave()
    {
        if (currentSet != null)
        {
            Destroy(currentSet);
        }

        yield return new WaitForSeconds(2);

        currentSet = Instantiate(allAliensSets[Random.Range(0, allAliensSets.Length)], spawnPos, Quaternion.identity);
        UIManager.UpdateWave();
    }
}