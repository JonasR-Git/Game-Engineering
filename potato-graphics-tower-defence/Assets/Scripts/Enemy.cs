using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    private float startHealth = 100;
    private int bounty = 10;
    private PlayerStats player;

    [HideInInspector] //So you can't change it from the Inspector
    public float speed;

    private float health;
    private bool isAlive = true;

    //Shows the healthBar and need to be % filled with % of the current health 
    public Image healthBar;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
        player = FindObjectOfType<PlayerStats>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        /*healthBar.fillAmount = health / startHealth;

        if (healthBar.fillAmount < 0.5)
        {
            //TODO after implementing the healthBar to change the color of the bar depending on the health
        }
        */
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
        player.ChangeMoney(bounty);
        WaveSpawner.AliveCounter--;
        Destroy(gameObject);
    }
    public void ReachedEnd()
    {
        Died();
    }




    //For testing functions:

    public float getHealth()
    {
        return health;
    }

    public float getStartHealth()
    {
        return startHealth;
    }
}
