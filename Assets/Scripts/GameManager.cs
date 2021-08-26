using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selectedchar;
    public GameObject Player;

    private Sprite playersprite;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        playersprite = selectedchar.GetComponent<SpriteRenderer>().sprite;

        Player.GetComponent<SpriteRenderer>().sprite = playersprite;
    }

    public static void CancelGame()
    {
        UIManager.ResetUI();
        AudioManager.StopBattleMusic();
    }

}
