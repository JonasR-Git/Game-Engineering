using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 180;

    public static int lives;
    public  int startLives = 30;
    public Text livesText;
    public Text moneyText;

    //Creating a Singleton Pattern Style to have only 1 Player in every Scene
    public static PlayerStats instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Only one Player should be instanciate");
            return;
        }
        instance = this;
    }


    void Start()
    {
        money = startMoney;
        lives = startLives;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money:" + PlayerStats.money.ToString();
        livesText.text = "Lives:" + PlayerStats.lives.ToString();
    }

    public void ChangeMoney(int bounty)
    {
        money += bounty;
    }
    public void ChangeLive(int payload)
    {
        lives = lives - payload;
        if (lives <= 0)
        {
            //Add Failure Sound here
            SceneManager.LoadScene("Main Menu");
        }
    }

    public int getMoney()
    {
        return money;
    }
    public int getLives()
    {
        return lives;
    }

    public int getStartMoney()
    {
        return startMoney;
    }

}
