using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoSingleton<MenuManager>
{
    [Header("References")]
    [SerializeField]
    private Transform menuHolder;
    [SerializeField]
    private Transform menuBackground;

    public void MoveMenu(int menuIndex)
    {
        menuHolder.DOLocalMoveX(menuIndex * 1280, TimeManager.GetUIDelay());
        menuBackground.DOLocalMoveX(menuIndex * 740, TimeManager.GetUIDelay());
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
