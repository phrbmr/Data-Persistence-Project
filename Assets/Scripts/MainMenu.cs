using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour {


    public TMP_Text bestScoreText;
    public TMP_InputField inputPlayerName;

    void Start() 
    {
        if (ScoreManager.Instance.currentPlayerName != "null not named yet") {
            BestScoreText();
        }
    }

    public void StartGame() 
    {
        ScoreManager.Instance.currentPlayerName = inputPlayerName.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        ScoreManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void BestScoreText() 
    {
        if (ScoreManager.Instance != null) {
            bestScoreText.SetText("Best Score: " + ScoreManager.Instance.bestPlayerName + " : " + ScoreManager.Instance.BestScore);
        }
        else {
            bestScoreText.SetText("Best Score: ");
        }
    }
}
