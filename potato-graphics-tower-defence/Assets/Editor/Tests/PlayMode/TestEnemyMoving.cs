using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Transform))]
public class TestEnemyMoving
{
    private GameObject testObject;
    private Enemy enemy;
    private Transform start;
    private Scene activeScene = SceneManager.GetActiveScene();
    // A Test behaves as an or dinary method

    [SetUp]
    public void Setup()
    {
        testObject = GameObject.Instantiate(new GameObject());
        enemy = GameObject.Instantiate(new Enemy());
        start = testObject.GetComponent<Transform>();
        var rootGameObjects = activeScene.GetRootGameObjects();
    }

    [UnityTest]
    public IEnumerable EnemyMovesAfterGameStarts()
    {
        Vector3 position = enemy.transform.position;

        yield return new WaitForSeconds(0.2f);

        Vector3 newPosition = enemy.transform.position;

        Assert.AreNotEqual(newPosition, position, "MoveTest Passed. Enemy moved from " + position + " to " + newPosition);
    }

    [UnityTest]
    public IEnumerator EnemyChangesDirection()
    {
        Vector3 position1 = enemy.transform.position;

        yield return new WaitForSeconds(0.05f);

        Vector3 position2 = enemy.transform.position;


        yield return new WaitForSeconds(2f);


        Vector3 newPosition1 = enemy.transform.position;

        yield return new WaitForSeconds(0.05f);

        Vector3 newPosition2 = enemy.transform.position;

        Assert.AreNotEqual((position2 - position1) , (newPosition2 - newPosition1), "MoveTest Passed. Enemy changed his moving direction from " + (position2 - position1) + " to " + (newPosition2 - newPosition1));
    }
}
