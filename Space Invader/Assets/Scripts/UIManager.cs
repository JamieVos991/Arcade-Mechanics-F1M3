using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    private static UIManager instance; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    public static void UpdateScore(int s)
    {
        instance.score += 5;
        instance.scoreText.text = instance.score.ToString("000");
    }
}
