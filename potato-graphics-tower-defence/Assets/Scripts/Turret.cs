using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //public for testing
    
    public Transform target;
    private bool targetfarthest = false;

    public float range = 12f; //3 Tiles

    public string enemyTag = "Enemy";

    public Transform partToRotate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTarget();
        //tower needs nothing to do while he has no target
        if (target == null)
            return;
    }

    //drawing the range from the turret if selected to adjust it better
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


    //The commented out lines are for different target priorising
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        float farthestDistance = 0;
        GameObject nearestEnemy = null;
        GameObject farthestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            if (distanceToEnemy > farthestDistance)
            {
                farthestDistance = distanceToEnemy;
                farthestEnemy = enemy;
            }
        }
        if (targetfarthest == false)
        {
            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
        else
        {
            if (farthestEnemy != null && farthestDistance <= range)
            {
                target = farthestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
    }
}

