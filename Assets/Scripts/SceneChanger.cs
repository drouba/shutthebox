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

        int endValue = GameManager.Instance.SumAvailableNum();

        if (endValue == 0)
        {
            SceneManager.LoadScene("Win");
        }
        else if (endValue > 0 && endValue < 6)
        {
            SceneManager.LoadScene("CloseWin");
        }
        else if(endValue >=4 && endValue < 9)
        {
            SceneManager.LoadScene("AlmostLose");
        }
        else
        {
            SceneManager.LoadScene("Lose");
        }

    }

}
