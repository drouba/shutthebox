using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicFadeOut : MonoBehaviour
{
    public AudioSource menuMusic;
    public int duration = 2;

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "ShutTheBox")
        {
            StartCoroutine("StartFadeOut");
        }
        else if(menuMusic.volume == 0 )
        {
            StartCoroutine("StartFadeIn");
        }
    }

    public IEnumerator StartFadeOut()
    {
        float currentTime = 0;
        float start = menuMusic.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            menuMusic.volume = Mathf.Lerp(start, 0, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public IEnumerator StartFadeIn()
    {
        float currentTime = 0;
        float start = menuMusic.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            menuMusic.volume = Mathf.Lerp(start, 1, currentTime / duration);
            yield return null;
        }
        yield break;
    }

}
