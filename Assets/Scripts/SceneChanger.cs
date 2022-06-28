using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("ShutTheBox");
    }

    public void Rules()
    {
        SceneManager.LoadScene("Rules");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void Lose()
    {
        Debug.Log("Load lose");
        SceneManager.LoadScene("Lose");
    }

}
