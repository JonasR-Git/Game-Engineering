using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTests
{
    [Test]
    public void TestMovingDirection()
    {
        //ARRANGE
        var gameObject = new GameObject();
        var enemy = gameObject.AddComponent<Enemy>();

        Transform target = Path.waypoints[0];
        Vector3 expected_dir = target.position - enemy.transform.position;

        //ACT

        //ASSERT

        Assert.AreEqual(expected_dir, (target.position - enemy.transform.position));
    }
}
