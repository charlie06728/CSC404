using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int player1Score = 0;
    public int player2Score = 0;

    public Text player1ScoreText;
    public Text player2ScoreText;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(string playerName)
    {
        if (playerName == "Player1")
        {
            player1Score++;
            UpdateScoreUI();
            Debug.Log("Player 1 scores!");
        }
        else if (playerName == "Player2")
        {
            player2Score++;
            UpdateScoreUI();
            Debug.Log("Player 2 scores!");
        }
    }

    private void UpdateScoreUI()
    {
        player1ScoreText.text = "Player 1: " + player1Score;
        player2ScoreText.text = "Player 2: " + player2Score;
    }

}
