using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI highScoreText;
    public bool contadorActivo { get; set; }
    int scoreNum;



    // Start is called before the first frame update
    void Start()
    {
        score.text = scoreNum.ToString();
        Invoke(nameof(UpdateScore), 1);
        contadorActivo = true;
    }

    private void UpdateScore()
    {
        if (!contadorActivo)
        {
            CheckForHighScore();
            return;
        }

        scoreNum++;
        score.text = scoreNum.ToString();
        Invoke(nameof(UpdateScore), 1);
    }

    private void CheckForHighScore()
    {
        if (scoreNum > PlayerPrefs.GetInt("HS"))
        {
            PlayerPrefs.SetInt("HS", scoreNum);
            PlayerPrefs.Save();
        }

        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HS")}";
    }
}
