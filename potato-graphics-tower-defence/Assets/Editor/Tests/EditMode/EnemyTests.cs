using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestRunner;

public class EnemyTests
{
    [UnityTest]
    public IEnumerator TestEnemyBountyIncrease() 
    {
        yield return null;
    }
    [UnityTest]
    public IEnumerator TestIncreaseMoneyUponEnemyKilled()
    {
        GameObject gameObj1 = new GameObject();
        GameObject gameObj2 = new GameObject();
        Enemy enemy = gameObj2.AddComponent<Enemy>();
        PlayerStats player = gameObj1.AddComponent<PlayerStats>();
        enemy.setPlayer(player);
        var moneyStart = player.getMoney();

        enemy.TakeDamage(enemy.getHealth());

        var moneyAfter = player.getMoney();

        var moneyexpected = moneyStart + 10;

        Assert.AreEqual(moneyAfter, moneyexpected);
        yield return null;
    }
    [UnityTest]
    public IEnumerator TestDecreaseLiveUponEnemyReachedEnd()
    {
        GameObject gameObj1 = new GameObject();
        GameObject gameObj2 = new GameObject();
        Enemy enemy = gameObj2.AddComponent<Enemy>();
        PlayerStats player = gameObj1.AddComponent<PlayerStats>();
        enemy.setPlayer(player);
        var livesStart = player.getLives();

        enemy.ReachedEnd();

        var liveAfter = player.getLives();

        var liveexpected = livesStart - 1;

        Assert.AreEqual(liveAfter, liveexpected);
        yield return null;
    }

}
