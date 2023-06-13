using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeManager : MonoSingleton<TimeManager>
{
    [SerializeField]
    private static float uiDelay = 0.125f;


    [Header("Level Time")]
    [SerializeField]
    private TextMeshProUGUI levelTimeText;
    [SerializeField]
    private float levelTime = 120;

    private void Start()
    {
        StartCoroutine(TimeProgressRoutine());
    }

    private IEnumerator TimeProgressRoutine()
    {
        while (levelTime > 0)
        {
            levelTime -= 1;

            int minutes = Mathf.FloorToInt(levelTime / 60f); // Calculate minutes
            int seconds = Mathf.FloorToInt(levelTime % 60f); // Calculate seconds

            string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

            levelTimeText.text = timeString;

            if (levelTime <= 15)
            {
                levelTimeText.color = Color.red;
            }

            yield return new WaitForSeconds(1);
        }

        levelTimeText.text = "00:00";

        LevelManager.singleton.FinishLevel(true);
    }

    public static float GetUIDelay()
    {
        return uiDelay;
    }

    public static float GetUIDelay2()
    {
        return uiDelay * 2;
    }

    public static float GetUIDelay4()
    {
        return uiDelay * 4;
    }

    public static float GetUIDelay8()
    {
        return uiDelay * 8;
    }
}
