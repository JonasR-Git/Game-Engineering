using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("musterscene");
    }
    public void leaveGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}