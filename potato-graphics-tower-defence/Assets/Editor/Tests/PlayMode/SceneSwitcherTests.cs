using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class SceneSwitcherTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void SceneSwitcherTestsSimplePasses()
    {
        SceneSwitcher sceneSwitcher = SceneSwitcher.instance;

        sceneSwitcher.playGame();

        Assert.AreEqual(SceneManager.GetActiveScene(), SceneManager.GetSceneByName("musterscene"));
    }
}