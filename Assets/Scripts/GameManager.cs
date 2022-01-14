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
    public int highScore = 0;
    // Start is called before the first frame update
    void Awake()
    {
        playername = "";


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
        playername = nameEntry.text;
        Debug.Log(playername);
    }
    public void StartGame()
    {
        if (playername != "")
        {
            SceneManager.LoadScene(1);
        }
        
    }

    [System.Serializable]
    class PlayerSave
    {
        public string highScorename;
        public int highScore;
    }
    public void SaveColor()
    {
       PlayerSave data = new PlayerSave();
        data.highScorename = playername;
        data.highScore = highScore;


    }
}
