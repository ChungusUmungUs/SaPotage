using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    public static PlayerManager instance;
    public List<Player> players = new List<Player>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIManager.instance.UpdateValues(players[0], players[1]);
    }

    internal void AssignTurn(int currentPlayerTurn)
    {
        foreach (Player player in players)
        {
            player.myTurn = player.ID == currentPlayerTurn;
        }
    }
    
    public void RaiseScore(int ID, int points)
    {
        Player player = FindPlayerByID(ID);
        player.score += points;
        if(player.score >= 20)
        {
            PlayerWin(ID);
        }
    }

    private void PlayerWin(int ID)
    {
        //???
    }

   public Player FindPlayerByID (int ID)
    {
        Player foundPlayer = null;
        foreach (Player player in players)
        {
            foundPlayer = player;
        }

        return foundPlayer;

    }
}
