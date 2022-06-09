using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using UnityEngine.TestTools;

public class TestUI : MonoBehaviour
{
    private int timeTillFirstWave = 1;
    //TODO: uncomplete
    [UnityTest]
    public IEnumerator SceneSwitcherIn()
    {
        SceneManager.LoadScene("Testscene");

        yield return new WaitForSecondsRealtime(timeTillFirstWave);

        Assert.AreEqual(SceneManager.GetActiveScene(),"Testscene");
    }
    [UnityTest]
    public IEnumerator SceneSwitcherOut()
    {
        SceneManager.LoadScene("Testscene");

        yield return new WaitForSecondsRealtime(timeTillFirstWave);

        Assert.AreEqual(SceneManager.GetActiveScene(), "Testscene");
    }

}
