using UnityEngine;
using UnityEngine.UI;

public class highscore_script : MonoBehaviour
{
    public Text highScore;

     void start ()
     {
        highScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString ();
     }
    
    void scores ()
    {
        int number = 0;
        highScore.text = number.ToString();

        if (number > PlayerPrefs.GetInt("Highscore", 0)) 
        {
            PlayerPrefs.SetInt("Highscore", number);
        }
    }
}
