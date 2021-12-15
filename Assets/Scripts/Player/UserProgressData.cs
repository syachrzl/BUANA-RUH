using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserProgressData {

    public float TotalPuzzle;
    public float[] position;
    public bool AlreadyTaken;

    public UserProgressData(PlayerManager pm)
    {
        TotalPuzzle = pm.TotalPuzzle;
        AlreadyTaken = PuzzleCollectible.alreadyTaken;

        position = new float[3];
        position[0] = PlayerManager.lastCheckPointPos.x;
        position[1] = PlayerManager.lastCheckPointPos.y;
        position[2] = PlayerManager.lastCheckPointPos.z;
    }
    
}
