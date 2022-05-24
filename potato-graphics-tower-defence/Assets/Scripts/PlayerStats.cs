using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 200;

    public static int lives;
    public  int startLives = 40;
    public Text livesText;
    public Text moneyText;
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
}
