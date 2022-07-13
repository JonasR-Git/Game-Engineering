using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //slow:6f, normal:12f, fast 24f
    public float startSpeed = 12f;
    public float startHealth = 100;
    public int startArmor = 0;
    public int startResistanceNormal = 0;
    public int startResistanceEnergy = 0;

    public int bounty = 1;
    public int payload = 1;

    private PlayerStats player;
    private WaveSpawner waveSpawner;

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
        player = PlayerStats.instance;
        waveSpawner = FindObjectOfType<WaveSpawner>();
        bounty = bounty * (waveSpawner.getWaveIndex() + 1);
    }

    public void TakeDamage(float damage)
    {
        float applied_damage;
        float applied_armor;
        //if damage_type = energy and startResistanceEnergy>=0
        //elif damage_type = normal and startResistanceEnergy>=0
        applied_armor = startArmor;
        applied_damage = damage - damage * applied_armor * (float)0.05;
        health -= applied_damage;

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

    public void Died()
    {
        isAlive = false;
        player.getMoney();
        player.ChangeMoney(bounty);
        WaveSpawner.AliveCounter--;
        if (Application.isPlaying)
        {
            Destroy(gameObject);
        }
       else
        {
            DestroyImmediate(gameObject);
        }
    }
    public void ReachedEnd()
    {
        isAlive = false;
        player.ChangeLive(payload);
        WaveSpawner.AliveCounter--;
        if (Application.isPlaying)
        {
            Destroy(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
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
    public PlayerStats getPlayer()
    {
        return player;
    }
    public void setPlayer(PlayerStats _player)
    {
        player = _player;
    }
    public void setSpawner(WaveSpawner _spawner)
    {
        waveSpawner = _spawner;
    }
}
