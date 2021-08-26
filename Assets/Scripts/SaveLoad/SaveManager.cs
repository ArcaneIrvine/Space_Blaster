using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        LoadProgress();
    }

    public static void SaveProgress()
    {
        SaveObject so = new SaveObject();

        so.highscore = UIManager.GetHighScore();
    }

    public static void LoadProgress()
    {
        SaveObject so = SaveLoad.LoadState();

        UIManager.UpdateHighScore(so.highscore);
    }
}
