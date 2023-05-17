using TMPro;
using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField] private TMP_Text scoreTxt, bestScoreTxt, gamesPlayedTxt;
    private int scoreValue = 0;

    private void Start()
    {
        scoreTxt.text = scoreValue.ToString();
        bestScoreTxt.text = "Best Score: " + PlayerPrefs.GetInt("BestScore").ToString();
        gamesPlayedTxt.text = "Games Played: " + PlayerPrefs.GetInt("GamesPlayed").ToString();
    }

    public void UpdateScore()
    {
        scoreValue++;
        scoreTxt.text = scoreValue.ToString();

        if (scoreValue > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", scoreValue);
        }
    }
}