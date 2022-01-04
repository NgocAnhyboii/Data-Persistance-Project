using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUiHandler : MonoBehaviour
{
    public TMP_InputField playernameInputField;
    public TMP_Text menuBestScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        if (ScoreManager.Instance != null)
        {
            SetBestScore(ScoreManager.Instance.HighscorePlayername, ScoreManager.Instance.Highscore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        ScoreManager.Instance.SaveHighscore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    

    public void PlayerNameInput()
    {
        string playername = playernameInputField.text;
        ScoreManager.Instance.Playername = playername;
    }
    void SetBestScore(string playername, int points)
    {
        menuBestScoreTxt.text = "Highscore: " + playername + " " + points;
    }
}
