using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenBank : MonoBehaviour
{
    
    public Token[] tokenBank;
    
    public Token SearchTokenbyRace(int raceID) {

        Token target = null;

        for (int i = 0; i < tokenBank.Length; i++) {

            if (tokenBank[i].raceID == raceID)
                target = tokenBank[i];

        }

        if (target == null)
            Debug.LogError("Null Reference.  Token of specified race not found.");
       
        return target;

    }

}
