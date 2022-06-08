using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //public for testing
    
    public Transform target;

    [Header("Stats")]

    public float attackSpeed = 1f;
    private float shootCountdown = 0f;
    public float range = 12f; //3 Tiles
    public bool targetfarthest = false;
    public float rotationSpeed = 15f;
    public float bulletSpeed = 50f;
    public float damage = 50f;

    [Header("Unity Stuff")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform bulletStartPoint;



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
        UpdateRotation();
        if (shootCountdown <= 0f)
        {
            Shoot();
            shootCountdown = 1f / attackSpeed;
        }

        shootCountdown -= Time.deltaTime;
    }
    



    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletStartPoint.position, bulletStartPoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bullet != null)
        {
            bulletScript.Prepare(target, bulletSpeed, damage);
        }
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

            if (distanceToEnemy > farthestDistance && distanceToEnemy < range)
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

    void UpdateRotation()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime*rotationSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}

