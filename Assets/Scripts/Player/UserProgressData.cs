using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserProgressData {

    //Satuan Puzzle
    public bool AlreadyTaken;
    public bool AlreadyTaken2;

    //Save Total Puzzle
    public float TotalPuzzle;
    
    //Player Position
    public float[] position;
    

    public UserProgressData(PlayerManager pm)
    {
        TotalPuzzle = pm.TotalPuzzle;
        AlreadyTaken = PuzzleCollectible.alreadyTaken;
        AlreadyTaken2 = PuzzleCollectible2.alreadyTaken2;

        position = new float[3];
        position[0] = PlayerManager.lastCheckPointPos.x;
        position[1] = PlayerManager.lastCheckPointPos.y;
        position[2] = PlayerManager.lastCheckPointPos.z;
    }
    
}
