using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScores : MonoBehaviour {

    public Text[] highscoreText;
    HighScores highscoreManager;

	void Start () {
		for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". Gathering info...";
        }
        highscoreManager = GetComponent<HighScores>();

        StartCoroutine(RefreshHighscores());
	}

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". ";
            if (highscoreList.Length > i)
            {
                highscoreText[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
        }
    }

    private IEnumerator RefreshHighscores()
    {
        while(true)
        {
            highscoreManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }
}
