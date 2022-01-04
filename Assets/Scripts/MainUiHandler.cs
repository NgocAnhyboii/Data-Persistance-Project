using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainUiHandler : MonoBehaviour
{

    public TMP_Text mainBestScoreTxt;

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
    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }

    void SetBestScore(string playername, int points)
    {
        mainBestScoreTxt.text = "Highscore: " + playername + " " + points;
    }
}
