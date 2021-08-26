using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    private bool muted;

    public AudioSource battlemusicsource;
    public AudioSource sfxsource;

    private bool isplaying;
    private float delay;

    private const float delaytick = 0.05f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        muted = PlayerPrefs.GetInt("MUTED") == 1;

        if (muted)
            AudioListener.pause = true;
    }

    public void ToggleMute()
    {
        muted = !muted;

        if (muted)
            PlayerPrefs.SetInt("MUTED", 1);
        else
            PlayerPrefs.SetInt("MUTED", 0);

        if (muted)
            AudioListener.pause = true;
        else
            AudioListener.pause = false;
    }

    public static void PlayBattleMusic()
    {
        instance.isplaying = true;
        instance.StartCoroutine(instance.BattleSound());
    }

    public static void StopBattleMusic()
    {
        instance.isplaying = false;
        instance.StopCoroutine(instance.BattleSound());
    }

    public static void PlaySoundEffect(AudioClip clip)
    {
        if (!instance.muted)
            instance.sfxsource.PlayOneShot(clip);
    }

    public static void UpdatebattleMusicDelay(int i)
    {
        float delayTime = i * delaytick;

        if (delayTime < 0.2f)
            delayTime = 0.2f;

        if (delayTime > 1)
            delayTime = 1;

        instance.delay = delayTime;
    }

    private IEnumerator BattleSound()
    {
        while (isplaying)
        {
            yield return new WaitForSeconds(delay);
            battlemusicsource.Play();
        }
    }

}
