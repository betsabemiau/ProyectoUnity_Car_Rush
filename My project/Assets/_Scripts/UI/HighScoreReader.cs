using TMPro;
using UnityEngine;

public class HighScoreReader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = $"High Score: {PlayerPrefs.GetInt("HS")}";   
    }
}
