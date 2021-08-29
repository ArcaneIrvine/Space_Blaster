using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject gameovermenu;
    public GameObject ingamemenu;
    public GameObject pausemenu;

    public static MenuManager instance;

    public static bool spawn;
    public static bool endspawn = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        ReturnToMainMenu();
    }

    public void OpenMainMenu()
    {
        instance.mainmenu.SetActive(true);
        instance.ingamemenu.SetActive(false);
    }

    public static void OpenGameOver()
    {
        Time.timeScale = 0;

        instance.gameovermenu.SetActive(true);
        instance.ingamemenu.SetActive(false);

        UIManager.HighScoreCheck();
    }

    public void OpenInGame()
    {
        spawn = true;

        Time.timeScale = 1;

        instance.mainmenu.SetActive(false);
        instance.pausemenu.SetActive(false);
        instance.gameovermenu.SetActive(false);
        instance.ingamemenu.SetActive(true);
    }

    public void OpenPause()
    {
        Time.timeScale = 0;
        instance.ingamemenu.SetActive(false);
        instance.pausemenu.SetActive(true);
    }

    public void ClosePause()
    {
        Time.timeScale = 1;
        instance.ingamemenu.SetActive(true);
        instance.pausemenu.SetActive(false);
    }

    public static void ReturnToMainMenu()
    {
        endspawn = true;
        Time.timeScale = 1;
        instance.gameovermenu.SetActive(false);
        instance.pausemenu.SetActive(false);
        instance.ingamemenu.SetActive(false);

        instance.mainmenu.SetActive(true);

        GameManager.CancelGame();
    }

    public static void CloseWindow(GameObject go)
    {
        go.SetActive(false);
    }

    //other Menus
}
