using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    public int Score { get; private set; } = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScore()
    {
        Score = 0;
        scoreText.text = "Score: 0";
    }

    public void IncrementScore()
    {
        Score++;
        scoreText.text = "Score: " + Score.ToString();
    }
}
