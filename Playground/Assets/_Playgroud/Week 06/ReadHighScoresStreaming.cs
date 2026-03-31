using UnityEngine;
using System.IO;
using System.Collections;
using UnityEngine.Networking;

public class ReadHighScoresStreaming : MonoBehaviour
{
    string path;
    string jsonFile = "streaming.json";

    private void Start()
    {   
        path = Path.Combine(Application.streamingAssetsPath, jsonFile);
        print(path);
        //StreamingJSON();
        StartCoroutine(WebRequestJSON());
    }

    IEnumerator WebRequestJSON()
    {
        UnityWebRequest www = UnityWebRequest.Get(path);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            print("ERROR: " + www.error);
        }
        else
        {
            string jsonString = www.downloadHandler.text;
            //TestStreams highscoresInJSON = JsonUtility.FromJson<TestStreams>(jsonString);
            //foreach (TestStream highscore in highscoresInJSON.highScores)
            HighScores highscoresInJSON = JsonUtility.FromJson<HighScores>(jsonString);
            foreach (HighScore highscore in highscoresInJSON.highScores)
            {
                print("Player Name: " + highscore.playerName + ", Player Score:" + highscore.playerScore);
            }
        }
    }
    private void StreamingJSON()
    {
        string jsonString = File.ReadAllText(path);

        HighScores highscoresInJSON = JsonUtility.FromJson<HighScores>(jsonString);
        foreach (HighScore highscore in highscoresInJSON.highScores)
        {
            print("Player Name: " + highscore.playerName + ", Player Score:" + highscore.playerScore);
        }
    }

    [System.Serializable]
    public struct TestStream
    {
        public string playerName;
        public int playerScore;
    }

    [System.Serializable]
    public struct TestStreams
    {
        public HighScore[] highScores;
    }
}
