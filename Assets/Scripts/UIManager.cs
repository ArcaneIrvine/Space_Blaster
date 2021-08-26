using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    private int score;

    public TextMeshProUGUI highscoretext;
    private int highscore;

    public Image[] lifesprites;

    private Color32 active = new Color(1, 1, 1, 1);
    private Color32 inactive = new Color(1, 1, 1, 0.25f);

    private static UIManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public static void UpdateLives(int l)
    {
        foreach (Image i in instance.lifesprites)
            i.color = instance.inactive;

        for (int i = 0; i < l; i++)
        {
            instance.lifesprites[i].color = instance.active;
        }
    }

    public static void UpdateScore(int s)
    {
        instance.score += s;
        instance.scoretext.text = instance.score.ToString("000,000");
    }

    public static void UpdateHighScore(int hs)
    {
        if (instance.highscore < hs)
        {
            instance.highscore = hs;
            instance.highscoretext.text = instance.score.ToString("000,000");
        }
    }

    public static void HighScoreCheck()
    {
        if (instance.highscore < instance.score)
        {
            UpdateHighScore(instance.score);
            SaveManager.SaveProgress();
        }
    }

    public static int GetHighScore()
    {
        return instance.highscore;
    }

    public static void ResetUI()
    {
        instance.score = 0;
        instance.scoretext.text = instance.score.ToString("000,000");

        foreach (Image i in instance.lifesprites)
            i.color = instance.active;

        MainPlayer.currentLives = 3;
    }
}
