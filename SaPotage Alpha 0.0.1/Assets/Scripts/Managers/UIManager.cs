using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI player0Score, player1Score, player0Plays, player1Plays;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateValues(Player player0, Player player1)
    {
        UpdateScoreValues(player0.score, player1.score);
        UpdatePlaysValues(player0.plays, player1.plays);
    }

    public void UpdateScoreValues(int player0Score, int player1Score)
    {
        this.player0Score.text = player0Score.ToString();
        this.player1Score.text = player1Score.ToString();
    }

    public void UpdatePlaysValues(int player0Plays, int player1Plays)
    {
        this.player0Plays.text = player0Plays.ToString();
        this.player1Plays.text = player1Plays.ToString();

    }
}
