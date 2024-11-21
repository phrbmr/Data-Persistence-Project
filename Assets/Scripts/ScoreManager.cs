using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int BestScore = 0;
    public string currentPlayerName = "null not named yet";
    public string bestPlayerName;

    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string currentPlayerName;
        public string bestPlayerName;
    }
    
    void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }


    public void SaveScore() 
    {
        SaveData data = new SaveData();
        data.BestScore = BestScore;
        data.bestPlayerName = bestPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScore;
            bestPlayerName = data.bestPlayerName;

        }
    }
}
