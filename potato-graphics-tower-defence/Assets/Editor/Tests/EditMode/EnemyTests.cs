using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestRunner;

public class EnemyTests : MonoBehaviour
{
    [Test]
    public void TestMovingDirectionStart()
    {
        //ARRANGE
        Transform enemy = GameObject.Find("Start").transform;
        GameObject Path = GameObject.Find("Waypoints");

        Transform target = Path.transform.Find("Waypoint");

        Vector3 expected_dir = target.position - enemy.position;

        //ACT

        //ASSERT

        Assert.AreEqual(expected_dir, (target.position - enemy.position));
    }
}
