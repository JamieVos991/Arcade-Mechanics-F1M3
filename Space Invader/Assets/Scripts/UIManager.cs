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

    public TextMeshProUGUI lifeText;
    private int life;

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

    public static void UpdateWave()
    {
        instance.wave++;
        instance.waveText.text = instance.wave.ToString();
    }

    public static void UpdateLives()
    {
        instance.life--;
        instance.lifeText.text = instance.life.ToString();
    }
}
