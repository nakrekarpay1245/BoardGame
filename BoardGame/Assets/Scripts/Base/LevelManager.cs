using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoSingleton<LevelManager>
{
    [Header("Level Manager References")]
    [Header("Pause Menu")]
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject pauseButton;

    [Header("Result Menu")]
    [SerializeField]
    private GameObject resultMenu;
    [SerializeField]
    private GameObject defeatIcon;
    [SerializeField]
    private GameObject victoryIcon;

    private bool isLevelFinished;

    public void PauseMenuButton()
    {
        pauseMenu.SetActive(!pauseMenu.gameObject.activeSelf);
        pauseButton.SetActive(!pauseMenu.gameObject.activeSelf);
    }

    public void FinishLevel(bool isLevelCompleted)
    {
        if (!isLevelFinished)
        {
            isLevelFinished = true;
            StartCoroutine(FinishLevelRoutine(isLevelCompleted));
        }
    }

    private IEnumerator FinishLevelRoutine(bool isLevelCompleted)
    {
        // all managers stop working!
        resultMenu.SetActive(true);
        defeatIcon.SetActive(!isLevelCompleted);
        victoryIcon.SetActive(isLevelCompleted);
        yield return new WaitForSeconds(TimeManager.GetUIDelay());
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}