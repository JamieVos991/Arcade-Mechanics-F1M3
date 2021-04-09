using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameOverMenu;
    public GameObject inGameMenu;
    public GameObject pauseMenu;

    public static MenuManager instance;

    private void Awake()
    {
        if(instance == null)
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
        ReturnToMainMenu();
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 1f;
        instance.mainMenu.SetActive(true);
        instance.inGameMenu.SetActive(false);
    }

    public static void OpenGameOver()
    {
        Time.timeScale = 0f;
        instance.gameOverMenu.SetActive(true);
        instance.inGameMenu.SetActive(false);
    }

    public void OnInGame()
    {
        Time.timeScale = 1f;
        instance.mainMenu.SetActive(false);
        instance.pauseMenu.SetActive(false);
        instance.gameOverMenu.SetActive(false);
        instance.inGameMenu.SetActive(true);

        WaveManager.SpawnNewWave();

    }

    public void OpenPause()
    {
        Time.timeScale = 0f;
        instance.inGameMenu.SetActive(false);
        instance.pauseMenu.SetActive(true);
    }

    public void ClosePause()
    {
        Time.timeScale = 1f;
        instance.inGameMenu.SetActive(true);
        instance.pauseMenu.SetActive(false);
    }

    public static void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        instance.gameOverMenu.SetActive(false);
        instance.pauseMenu.SetActive(false);
        instance.inGameMenu.SetActive(false);

        instance.mainMenu.SetActive(true);
        WaveManager.CancelGame();

    }

    public static void CloseWindow(GameObject go)
    {
        go.SetActive(false);
    }
}
