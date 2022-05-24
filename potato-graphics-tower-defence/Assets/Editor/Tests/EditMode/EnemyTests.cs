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
        Transform enemy = GameObject.Find("Start").transform;
        GameObject Path = GameObject.Find("Waypoints");

        Transform target = Path.transform.Find("Waypoint");

        Assert.IsNotNull(target.position - enemy.position);
    }

}
