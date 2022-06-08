using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools.Utils;
using System;
using UnityEditor;
using System.Runtime.Serialization;

public class PlayerTests
{
 
    public static T Create<T>()
    {
        return (T)FormatterServices.GetUninitializedObject(typeof(T));
    }

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

    [UnityTest]
    public IEnumerator MonoBehaviourTest ()
    {
        var enemy = Create<Enemy>();
        var player = Create<PlayerStats>();
        var playermoney = player.getMoney();

        Debug.Log(enemy.getHealth());

        enemy.TakeDamage(enemy.getHealth());

        Debug.Log(player.getMoney());
        Debug.Log(enemy.getHealth());
        

        Assert.AreNotEqual(playermoney, player.getMoney());

        yield return 0;

    }
 

    
}
