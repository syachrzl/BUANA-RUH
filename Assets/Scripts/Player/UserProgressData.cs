using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserProgressData {

    //Puzzle
    public bool AlreadyTaken;
    public float TotalPuzzle;
    public float IdPuzzle;


    //Player Position
    public float[] position;
    

    public UserProgressData(PlayerManager pm)
    {
        TotalPuzzle = pm.TotalPuzzle;
        AlreadyTaken = PuzzleCollectible.alreadyTaken;
        //IdPuzzle = PuzzleCollectible.IdPuzzle;

        position = new float[3];
        position[0] = PlayerManager.lastCheckPointPos.x;
        position[1] = PlayerManager.lastCheckPointPos.y;
        position[2] = PlayerManager.lastCheckPointPos.z;
    }
    
}
