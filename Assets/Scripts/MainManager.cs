using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public Color ChosenColor;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }
    
    
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.ChosenColor = ChosenColor;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    
    public void LoadColor()
    {
        var path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            ChosenColor = data.ChosenColor;
        }
    }
}
