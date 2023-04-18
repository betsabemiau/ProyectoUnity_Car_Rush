using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;

    int scoreNum;
    // Start is called before the first frame update
    void Start()
    {
        score.text = scoreNum.ToString();
        Invoke(nameof(UpdateScore), 1);
    }

    private void UpdateScore()
    {
        scoreNum++;
        score.text = scoreNum.ToString();
        Invoke(nameof(UpdateScore), 1);
    }
}
