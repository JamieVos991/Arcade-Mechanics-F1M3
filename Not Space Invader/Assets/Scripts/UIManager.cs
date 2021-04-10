using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    public TextMeshProUGUI waveText;
    private int wave;

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
        instance.score += s;
        instance.scoreText.text = instance.score.ToString("000");

    }

    public static void UpdateWave()
    {
        instance.wave++;
        EnemyInput.shootTimer--;
        instance.waveText.text = instance.wave.ToString();
    }

    public static void ResetUI()
    {
        instance.score = 0;
        instance.wave = 0;
        instance.scoreText.text = instance.score.ToString("000");
        instance.waveText.text = instance.wave.ToString();
    }
}