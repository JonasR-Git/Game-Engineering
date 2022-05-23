using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools.Utils;
using System;

public class TestEnemyMoving
{

    [UnityTest]
    public IEnumerator EnemyMovesAfterGameStarts()
    {
        SceneManager.LoadScene("musterscene");

        //Wait for the first Wave (Enemy Spawning)
        yield return new WaitForSecondsRealtime(8);

        //Get an Enemy which is spawned
        var enemy = GameObject.FindObjectOfType<Enemy>();

        Vector3 position = enemy.transform.position;

        yield return new WaitForSeconds(0.2f);

        Vector3 newPosition = enemy.transform.position;

        Assert.AreNotEqual(newPosition, position, "MoveTest failed. Enemy position ist " + position + " and " + newPosition);
    }


    [UnityTest]
    public IEnumerator EnemyChangesDirection()
    {
        SceneManager.LoadScene("musterscene");

        var comparer = new Vector3EqualityComparer(0.05f);

        //Wait for the first Wave (Enemy Spawning)
        yield return new WaitForSecondsRealtime(8);

        //Get an Enemy which is spawned
        var enemy = GameObject.FindObjectOfType<Enemy>();
       
        Vector3 position1 = enemy.transform.position;

        yield return new WaitForSeconds(0.05f);

        Vector3 position2 = enemy.transform.position;


        yield return new WaitForSeconds(2f);


        Vector3 newPosition1 = enemy.transform.position;

        yield return new WaitForSeconds(0.05f);

        Vector3 newPosition2 = enemy.transform.position;

        

        Assert.That((position2 - position1) , Is.Not.EqualTo(newPosition2 - newPosition1).Using(comparer), "MoveTest failed. Enemy changed doen't changed his moving direction: " + (position2 - position1) + " after: " + (newPosition2 - newPosition1));
    }
}
