using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools.Utils;
using System;
using UnityEditor;

public class PlayerTests
{
    [UnityTest]
    public IEnumerator AddMoneyIfEnemyDies ()
    {
        SceneManager.LoadScene("Testscene");

        //Wait for the first Wave (Enemy Spawning)
        yield return new WaitForSecondsRealtime(8);

        var player = GameObject.FindObjectOfType<PlayerStats>();
        var playermoney = player.getStartMoney();

        //Get an Enemy which is spawned
        var enemy = GameObject.FindObjectOfType<Enemy>();

        enemy.TakeDamage(enemy.getHealth() +1f);

        Assert.AreNotEqual(playermoney, player.getMoney());
    }
}
