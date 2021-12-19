using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public string playerName;
    public string highScorePlayerName;
    public int highScore;

    [Space]

    [SerializeField] bool resetHighScore;

    void Awake () {
        if (Instance == null) {
            Instance = this;
        }
        else if (Instance != null) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update () {
        if (resetHighScore) {
            ResetHighScoreData();
        }
    }

    class SaveData {
        public string highScorePlayerName;
        public int highScore;

        public SaveData (string name, int highScore) {
            this.highScorePlayerName = name;
            this.highScore = highScore;
        }
    }

    public void SaveHighScoreData () {
        SaveData saveData = new SaveData(highScorePlayerName, highScore);

        string jsonSaveData = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/SaveData.json", jsonSaveData);
    }

    public void LoadHighScoreData () {
        string saveDataPath = Application.persistentDataPath + "/SaveData.json";

        if (File.Exists(saveDataPath)) {
            string dataInJson = File.ReadAllText(saveDataPath);

            SaveData saveData = JsonUtility.FromJson<SaveData>(dataInJson);

            highScorePlayerName = saveData.highScorePlayerName;
            highScore = saveData.highScore;
        }
    }
    public void ResetHighScoreData () {
        SaveData saveData = new SaveData("", 0);

        string jsonSaveData = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/SaveData.json", jsonSaveData);
    }
}
