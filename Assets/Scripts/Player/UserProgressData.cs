using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserProgressData {

    //Puzzle
    public bool AlreadyTaken;
    public float TotalPuzzle;
   // public float[] unique;

    //Player Position
    public float[] position;
    

    public UserProgressData(PlayerManager pm)
    {
        TotalPuzzle = pm.TotalPuzzle;
        AlreadyTaken = PuzzleCollectible.alreadyTaken;

     //   unique = new float[5];

      //  for (int i = 0; i <= 5; i++)
      //  {
       //     if(PuzzleCollectible.unique == 0)
       //     {
               //Tidak melakukan apapun
       //     } else { 
        //        unique[i] = PuzzleCollectible.unique;
        //    }
     //   }

        position = new float[3];
        position[0] = PlayerManager.lastCheckPointPos.x;
        position[1] = PlayerManager.lastCheckPointPos.y;
        position[2] = PlayerManager.lastCheckPointPos.z;
    }
    
}
