using System.IO;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }
    public static PlayerData Instance;
    public string PlayerName;
    public int PlayerScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void SaveNewData(int recordScore)
    {
        Debug.Log("Saving Score " +  recordScore + " as name of " + PlayerName);
        SaveData data = new SaveData();
        data.name = PlayerName;
        PlayerScore = recordScore;
        data.score = recordScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/SaveData.json", json);
        Debug.Log("Successfully Saved Score " + data.name + " as name of " + data.score + " at " + Application.persistentDataPath);
    }
    public void LoadData()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/SaveData.json");
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        PlayerName = data.name;
        PlayerScore = data.score;
    }
}
