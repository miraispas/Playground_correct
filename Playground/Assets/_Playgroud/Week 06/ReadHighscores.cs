using UnityEngine;

public class ReadHighscores : MonoBehaviour
{
    [SerializeField]
    private TextAsset jsonText;

    private void Start()
    {
        HighScores highscoresInJSON = JsonUtility.FromJson<HighScores>(jsonText.text);
        //print(highscoresInJSON.highscores[0].playerName);
        for (int i = 0; i < highscoresInJSON.highScores.Length; i++)
        {
            HighScore highscore = highscoresInJSON.highScores[i];
            print("Player Name: " + highscore.playerName + ", Player Score:" + highscore.playerScore);
        }
    }
}

[System.Serializable]
public struct HighScore
{
    public string playerName;   
    public int playerScore; 
}

[System.Serializable]
public struct HighScores
{
    public HighScore[] highScores;
}