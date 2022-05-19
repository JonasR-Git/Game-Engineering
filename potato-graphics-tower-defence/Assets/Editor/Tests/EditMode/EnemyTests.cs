using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTests
{
    [Test]
    public void TestMovingDirectionStart()
    {
        //ARRANGE
        var enemy = GameObject.Find("Start").transform;
        GameObject Path = GameObject.Find("Waypoints");

        Transform target = Path.transform.Find("Waypoint");

        Vector3 expected_dir = target.position - enemy.transform.position;

        //ACT

        //ASSERT

        Assert.AreEqual(expected_dir, (target.position - enemy.transform.position));
    }
}