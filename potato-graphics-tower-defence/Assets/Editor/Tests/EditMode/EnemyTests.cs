using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestRunner;

public class EnemyTests
{
    [Test]
    public void TestIncreaseMoneyUponEnemyKilled()
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
    }

}
