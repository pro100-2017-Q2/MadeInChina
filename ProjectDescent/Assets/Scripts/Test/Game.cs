using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            int score = Random.Range(0, 500);
            string username = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            for(int i = 0; i < Random.Range(0, 10); i++)
            {
                username += alphabet[Random.Range(0, alphabet.Length)];
            }

            HighScores.AddNewHighscore(username, score);
        }
    }
}
