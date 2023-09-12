using System;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{        
    [SerializeField] private Image RocketHealth;

    [SerializeField] private Text CoinsCount;
    [SerializeField] private Text ScoreCount;
    [SerializeField] private Text HighscoreCount;

    [SerializeField] private AudioSource CoinAudio;
    [SerializeField] private AudioSource AsteroidAudio;

    [SerializeField] private GameObject TryAgainButton;
    [SerializeField] private GameObject BackToMenuButton;    
        
    private int coins;
    private float score;
    private int highscore;

    private float healthFill = 1f;

    private int maxHealth = 3;
    private float health;

    private int scoreBoost;
    private int coinBoost;

    private void Start()
    {
        LoadData();
        health = 3;
        RocketHealth.fillAmount = healthFill;
    }

    private void Update()
    {
        AddScore();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Coin")
        {
            OnCoinTake();
        }
        if (col.tag == "Asteroid")
        {
           OnAsteroidCol();
        }
        
        Destroy(col.gameObject);
    }
    private void OnCoinTake()
    {
        coins += 1 * coinBoost;
        CoinsCount.text = coins.ToString();
        CoinAudio.Play();
    }
    private void OnAsteroidCol()
    {
        health--;
        AsteroidAudio.Play();
        RocketHealth.fillAmount = health/maxHealth;

        if (health <= 0) 
        {
            OnDead(); 
        }
    }
    private void OnDead()
    {
        TryAgainButton.SetActive(true);
        BackToMenuButton.SetActive(true);
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            SetHighscore(score);
        }
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins", 0) + coins);
        Destroy(gameObject);
    }

    private void SetHighscore(float currentscore)
    {
        highscore = (int)Math.Round(currentscore,0);
        PlayerPrefs.SetInt("Highscore", highscore);
        HighscoreCount.text = highscore.ToString();
    }
    private void AddScore()
    {
        score += 1.5f * scoreBoost * Time.deltaTime;
        ScoreCount.text = Math.Round(score, 0).ToString();

    }

    private void LoadData()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        HighscoreCount.text = highscore.ToString();

        scoreBoost = PlayerPrefs.GetInt("ScoreBoost", 1);
        coinBoost = PlayerPrefs.GetInt("CoinBoost", 1);
    }
}
