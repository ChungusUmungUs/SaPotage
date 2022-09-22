using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Player
{
    public int score, plays;
    public int ID;
    public bool myTurn; 

    public Player(int score, int ID, int plays)
    {
        this.score = score;
        this.plays = plays;
        this.ID = ID;
    }
}
