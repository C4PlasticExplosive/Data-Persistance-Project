using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
public class GameManager : MonoBehaviour
{
    public string playername;
    public string highScoreName;
    public TMP_InputField nameEntry;
    public static GameManager Instance;
    public int highScore;
    // Start is called before the first frame update
    void Awake()
    {

        LoadHighScore();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(highScore);
    }
    public void StartGame()
    {
        UpdateName();
        if (playername != "")
        {
            SceneManager.LoadScene(1);
        }
        
    }

    public void UpdateName()
    {
        playername = nameEntry.text;
    }

    [System.Serializable]
    class PlayerSave
    {
        public string highScorename;
        public int highScore;
    }
    public void UpdateHighScore()
    {
       PlayerSave data = new PlayerSave();
        data.highScorename = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerSave data = JsonUtility.FromJson<PlayerSave>(json);

            highScoreName = data.highScorename;
            highScore = data.highScore;
        }
    }
}
