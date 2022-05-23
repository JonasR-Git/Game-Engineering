using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float speed;

    private float startHealth = 100;
    private float health;

    private int bounty = 10;

    private bool isAlive = true;

    private Transform target;
    private int wavepointIndex = 0;


    //Shows the healthBar and need to be % filled with % of the current health 
    public Image healthBar;

    void Start()
    {
        target = Path.waypoints[0];
        speed = startSpeed;
        health = startHealth;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        
        //Time.deltaTime is needed to run the speed indipendent on the framerate
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Path.waypoints.Length - 1)
        {
            Destroy(gameObject);
            //Don't jump to the lower code before Destroying the gameObject
            return;
        }

        wavepointIndex++;
        target = Path.waypoints[wavepointIndex];
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;
        if (healthBar.fillAmount < 0.5)
        {
            //TODO after implementing the healthBar
        }
        
        if (health <= 0 && isAlive)
        {
            Died();
        }
    }
    public void Slow(float slow)
    {
        speed = startSpeed * (1f - slow);
    }

    public void Fast(float fast)
    {
        speed = startSpeed * (1f + fast);
    }

    public void normalSpeed()
    {
        speed = startSpeed;
    }

    void Died()
    {
        isAlive = false;

        WaveSpawner.AliveCounter--;

        Destroy(gameObject);
    }

}
