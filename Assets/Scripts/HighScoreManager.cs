using System;
using System.IO;
using UnityEngine;

public static class HighScoreManager
{
    private static string filePath = Application.persistentDataPath + "/highscore.json";

    [Serializable]
    public class HighScoreData
    {
        public string PlayerName;
        public int Score;
    }

    public static void SaveHighScore(string playerName, int score)
    {
        HighScoreData data = new HighScoreData
        {
            PlayerName = playerName,
            Score = score
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public static HighScoreData LoadHighScore()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<HighScoreData>(json);
        }

        return new HighScoreData { PlayerName = "None", Score = 0 };
    }
}
