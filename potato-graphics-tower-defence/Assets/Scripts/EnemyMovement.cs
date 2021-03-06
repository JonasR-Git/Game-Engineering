using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Path.waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;

        //Time.deltaTime is needed to run the speed indipendent on the framerate
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Path.waypoints.Length - 1)
        {
            enemy.ReachedEnd();
            Destroy(gameObject);
            //Don't jump to the lower code before Destroying the gameObject
            return;
        }

        wavepointIndex++;
        target = Path.waypoints[wavepointIndex];
    }
}