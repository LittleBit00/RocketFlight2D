using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Text CurrentCoinBoost;
    [SerializeField] private Text NextCoinBoost;
    [SerializeField] private Text CurrentScoreBoost;
    [SerializeField] private Text NextScoreBoost;
    [SerializeField] private Text CurrentTurnSpeedBoost;
    [SerializeField] private Text NextTurnSpeedBoost;

    [SerializeField] private Text CoinBoostCost;
    [SerializeField] private Text ScoreBoostCost;
    [SerializeField] private Text TurnSpeedBoostCost;

    [SerializeField] private AudioSource ClickSound;
    [SerializeField] private AudioSource LevelUpSound;

    [SerializeField] private Text TotalCoins;
 
    private void Start()
    {
        Time.timeScale = 1;
        LoadSavedData();               
    }

    private void LvlUp(string boostShopName, string boostName, int boostCost, Text CostText)
    {
        if (PlayerPrefs.GetInt("TotalCoins", 0) >= boostCost)
        {
            SpendMoney(boostCost);
            IncreaseBoost(boostName);

            boostCost *= 2;
            PlayerPrefs.SetInt(boostShopName, boostCost);
            CostText.text = (boostCost).ToString();
            LevelUpSound.Play();

        }
    }
    private void SpendMoney(int moneyCost)
    {
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins", 0)-moneyCost);
        TotalCoins.text = PlayerPrefs.GetInt("TotalCoins", 0).ToString();
    }
    private void IncreaseBoost(string boostName)
    {
        if (boostName == "TurnSpeedBoost")
        {
            PlayerPrefs.SetFloat(boostName, PlayerPrefs.GetFloat(boostName, 1f) + 0.2f);
        }
        else
        {
            PlayerPrefs.SetInt(boostName, PlayerPrefs.GetInt(boostName, 1) + 1);
        }
    }

    public void UpCoinBoost()
    {
        LvlUp("CoinBoostCost", "CoinBoost", PlayerPrefs.GetInt("CoinBoostCost", 50), CoinBoostCost);
        UpdadteBoosterInfo("CoinBoost", CurrentCoinBoost, NextCoinBoost);
    }
    public void UpScoreBoost()
    {
        LvlUp("ScoreBoostCost", "ScoreBoost", PlayerPrefs.GetInt("ScoreBoostCost", 50), ScoreBoostCost);
        UpdadteBoosterInfo("ScoreBoost", CurrentScoreBoost, NextScoreBoost);
    }
    public void UpTurnSpeedBoost()
    {
        LvlUp("TurnSpeedBoostCost", "TurnSpeedBoost", PlayerPrefs.GetInt("TurnSpeedBoostCost", 50), TurnSpeedBoostCost);
        UpdadteBoosterInfo("TurnSpeedBoost", CurrentTurnSpeedBoost, NextTurnSpeedBoost);
    }

    private void LoadSavedData()
    {
        TotalCoins.text = PlayerPrefs.GetInt("TotalCoins", 0).ToString();

        CoinBoostCost.text = PlayerPrefs.GetInt("CoinBoostCost", 50).ToString();
        ScoreBoostCost.text = PlayerPrefs.GetInt("ScoreBoostCost", 50).ToString();
        TurnSpeedBoostCost.text = PlayerPrefs.GetInt("TurnSpeedBoostCost", 50).ToString();

        UpdadteBoosterInfo("CoinBoost", CurrentCoinBoost, NextCoinBoost);
        UpdadteBoosterInfo("ScoreBoost", CurrentScoreBoost, NextScoreBoost);
        UpdadteBoosterInfo("TurnSpeedBoost", CurrentTurnSpeedBoost, NextTurnSpeedBoost);
    }

    private void UpdadteBoosterInfo(string boostName, Text CurrentBoost, Text NextBoost)
    {
        if (boostName == "TurnSpeedBoost")
        {
            CurrentBoost.text = PlayerPrefs.GetFloat(boostName, 1f).ToString();
            NextBoost.text = (PlayerPrefs.GetFloat(boostName, 1f) + 0.2f).ToString();
        }
        else
        {
            CurrentBoost.text = PlayerPrefs.GetInt(boostName, 1).ToString();
            NextBoost.text = (PlayerPrefs.GetInt(boostName, 1) + 1).ToString();
        }
        
    }
}
