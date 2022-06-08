using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestRunner;

public class EnemyTests
{
    [Test]
    public void TestMovingDirectionStart()
    {
        GameObject gameObj1 = new GameObject();
        WaveSpawner waveSpawner = gameObj1.AddComponent<WaveSpawner>();
        PlayerStats player = gameObj1.AddComponent<PlayerStats>();
        Enemy enemy = gameObj1.AddComponent<Enemy>();

        var moneyStart = player.getMoney();

        enemy.TakeDamage(enemy.getHealth());

        var moneyAfter = player.getMoney();

        var moneyexpected = moneyStart + 10;

        Assert.AreEqual(moneyAfter, moneyexpected);
    }

}
