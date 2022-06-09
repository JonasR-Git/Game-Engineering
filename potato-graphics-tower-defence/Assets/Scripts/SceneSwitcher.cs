using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Only one SceneSwitcher should be instanciate");
            return;
        }
        instance = this;
    }

    public void playGame()
    {
        SceneManager.LoadScene("musterscene");
    }
    public void leaveGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
