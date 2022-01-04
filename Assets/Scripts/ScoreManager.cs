using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string Playername;
    public string HighscorePlayername;
    public int Highscore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighscore();
    }
    [System.Serializable]
    class SaveData
    {
        public string HighscorePlayername;
        public int Highscore;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.HighscorePlayername = HighscorePlayername;
        data.Highscore = Highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/highscorefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/highscorefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighscorePlayername = data.HighscorePlayername;
            Highscore = data.Highscore;
        }
    }
}
