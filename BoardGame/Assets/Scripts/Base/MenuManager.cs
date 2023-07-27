using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections.Generic;

public class MenuManager : MonoSingleton<MenuManager>
{
    [Header("References")]
    [SerializeField]
    private Transform menuHolder;
    [SerializeField]
    private List<Transform> menuTravelButtonList;

    public void MoveMenu(int menuIndex)
    {
        menuHolder.DOLocalMoveX(menuIndex * 1280, TimeManager.GetUIDelay());

        for (int i = 0; i < menuTravelButtonList.Count; i++)
        {
            menuTravelButtonList[i].transform.DOLocalMoveY(0, TimeManager.GetUIDelay());
            menuTravelButtonList[i].transform.DOScale(1, TimeManager.GetUIDelay());
        }

        menuTravelButtonList[Mathf.Abs(menuIndex - 2)].transform.DOLocalMoveY(75, TimeManager.GetUIDelay());
        menuTravelButtonList[Mathf.Abs(menuIndex - 2)].transform.DOScale(1.25f, TimeManager.GetUIDelay());
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}