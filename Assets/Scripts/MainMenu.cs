using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject quitPrompt, audio, creditsPanel, resetPanel;
    public Text[] tictactoeNames, tictactoeScores, connectfourNames, connectfourScores;

    int[,] scores = new int[2, 5];

    private void Start()
    {
        GameObject[] audios = GameObject.FindGameObjectsWithTag("audio BG");
        if (audios.Length != 1)
        {
            for (int i = 1; i < audios.Length; i++)
            {
                Destroy(audios[i]);
            }
        }

        if (SceneManager.GetActiveScene().name == "MainMenu")
            displayScores();
    }
    void displayScores()
    {
        for(int i = 0; i < 5; i++)
        {
            tictactoeNames[i].text = PlayerPrefs.GetString("TTTname " + (i + 1));
            tictactoeScores[i].text = PlayerPrefs.GetInt("TTT " + (i + 1), 0).ToString();
            connectfourNames[i].text = PlayerPrefs.GetString("CFname " + (i + 1));
            connectfourScores[i].text = PlayerPrefs.GetInt("CF " + (i + 1), 0).ToString();
        }
    }
    public void updateHighScores(string game, string name, int score)
    {
        int[,] scores = new int[2,5];

        for (int i = 0; i < 5; i++)
        {
            scores[0,i] = PlayerPrefs.GetInt("TTT " + (i + 1), 0);
            scores[1, i] = PlayerPrefs.GetInt("CF " + (i + 1), 0);
        }
        if (game == "TTT" && score != 0)
        {
            if (score >= scores[0, 0] && score >= scores[0, 1] && score >= scores[0, 2] && score >= scores[0, 3] && score >= scores[0, 4])
            {
                PlayerPrefs.SetInt("TTT 5", PlayerPrefs.GetInt("TTT 4"));
                PlayerPrefs.SetInt("TTT 4", PlayerPrefs.GetInt("TTT 3"));
                PlayerPrefs.SetInt("TTT 3", PlayerPrefs.GetInt("TTT 2"));
                PlayerPrefs.SetInt("TTT 2", PlayerPrefs.GetInt("TTT 1"));
                PlayerPrefs.SetInt("TTT 1", score);

                PlayerPrefs.SetString("TTTname 5", PlayerPrefs.GetString("TTTname 4"));
                PlayerPrefs.SetString("TTTname 4", PlayerPrefs.GetString("TTTname 3"));
                PlayerPrefs.SetString("TTTname 3", PlayerPrefs.GetString("TTTname 2"));
                PlayerPrefs.SetString("TTTname 2", PlayerPrefs.GetString("TTTname 1"));
                PlayerPrefs.SetString("TTTname 1", name);
            }
            else if (score >= scores[0, 1] && score >= scores[0, 2] && score >= scores[0, 3] && score >= scores[0, 4])
            {
                PlayerPrefs.SetInt("TTT 5", PlayerPrefs.GetInt("TTT 4"));
                PlayerPrefs.SetInt("TTT 4", PlayerPrefs.GetInt("TTT 3"));
                PlayerPrefs.SetInt("TTT 3", PlayerPrefs.GetInt("TTT 2"));
                PlayerPrefs.SetInt("TTT 2", score);

                PlayerPrefs.SetString("TTTname 5", PlayerPrefs.GetString("TTTname 4"));
                PlayerPrefs.SetString("TTTname 4", PlayerPrefs.GetString("TTTname 3"));
                PlayerPrefs.SetString("TTTname 3", PlayerPrefs.GetString("TTTname 2"));
                PlayerPrefs.SetString("TTTname 2", name);
            }
            else if (score >= scores[0, 2] && score >= scores[0, 3] && score >= scores[0, 4])
            {
                PlayerPrefs.SetInt("TTT 5", PlayerPrefs.GetInt("TTT 4"));
                PlayerPrefs.SetInt("TTT 4", PlayerPrefs.GetInt("TTT 3"));
                PlayerPrefs.SetInt("TTT 3", score);

                PlayerPrefs.SetString("TTTname 5", PlayerPrefs.GetString("TTTname 4"));
                PlayerPrefs.SetString("TTTname 4", PlayerPrefs.GetString("TTTname 3"));
                PlayerPrefs.SetString("TTTname 3", name);
            }
            else if (score >= scores[0, 3] && score >= scores[0, 4])
            {
                PlayerPrefs.SetInt("TTT 5", PlayerPrefs.GetInt("TTT 4"));
                PlayerPrefs.SetInt("TTT 4", score);

                PlayerPrefs.SetString("TTTname 5", PlayerPrefs.GetString("TTTname 4"));
                PlayerPrefs.SetString("TTTname 4", name);
            }
            else if (score >= scores[0, 4])
            {
                PlayerPrefs.SetInt("TTT 5", score);
                PlayerPrefs.SetString("TTTname 5", name);
            }
        }
        if (game == "CF" && score != 0)
        {
            if (score >= scores[1, 0] && score >= scores[1, 1] && score >= scores[1, 2] && score >= scores[1, 3] && score >= scores[1, 4])
            {
                PlayerPrefs.SetInt("CF 5", PlayerPrefs.GetInt("CF 4"));
                PlayerPrefs.SetInt("CF 4", PlayerPrefs.GetInt("CF 3"));
                PlayerPrefs.SetInt("CF 3", PlayerPrefs.GetInt("CF 2"));
                PlayerPrefs.SetInt("CF 2", PlayerPrefs.GetInt("CF 1"));
                PlayerPrefs.SetInt("CF 1", score);

                PlayerPrefs.SetString("CFname 5", PlayerPrefs.GetString("CFname 4"));
                PlayerPrefs.SetString("CFname 4", PlayerPrefs.GetString("CFname 3"));
                PlayerPrefs.SetString("CFname 3", PlayerPrefs.GetString("CFname 2"));
                PlayerPrefs.SetString("CFname 2", PlayerPrefs.GetString("CFname 1"));
                PlayerPrefs.SetString("CFname 1", name);

            }
            else if (score >= scores[1, 1] && score >= scores[1, 2] && score >= scores[1, 3] && score >= scores[1, 4])
            {
                PlayerPrefs.SetInt("CF 5", PlayerPrefs.GetInt("CF 4"));
                PlayerPrefs.SetInt("CF 4", PlayerPrefs.GetInt("CF 3"));
                PlayerPrefs.SetInt("CF 3", PlayerPrefs.GetInt("CF 2"));
                PlayerPrefs.SetInt("CF 2", score);

                PlayerPrefs.SetString("CFname 5", PlayerPrefs.GetString("CFname 4"));
                PlayerPrefs.SetString("CFname 4", PlayerPrefs.GetString("CFname 3"));
                PlayerPrefs.SetString("CFname 3", PlayerPrefs.GetString("CFname 2"));
                PlayerPrefs.SetString("CFname 2", name);
            }
            else if (score >= scores[1, 2] && score >= scores[1, 3] && score >= scores[1, 4])
            {
                PlayerPrefs.SetInt("CF 5", PlayerPrefs.GetInt("CF 4"));
                PlayerPrefs.SetInt("CF 4", PlayerPrefs.GetInt("CF 3"));
                PlayerPrefs.SetInt("CF 3", score);

                PlayerPrefs.SetString("CFname 5", PlayerPrefs.GetString("CFname 4"));
                PlayerPrefs.SetString("CFname 4", PlayerPrefs.GetString("CFname 3"));
                PlayerPrefs.SetString("CFname 3", name);
            }
            else if (score >= scores[1, 3] && score >= scores[1, 4])
            {
                PlayerPrefs.SetInt("CF 5", PlayerPrefs.GetInt("CF 4"));
                PlayerPrefs.SetInt("CF 4", score);

                PlayerPrefs.SetString("CFname 5", PlayerPrefs.GetString("CFname 4"));
                PlayerPrefs.SetString("CFname 4", name);
            }
            else if (score >= scores[1, 4])
            {
                PlayerPrefs.SetInt("CF 5", score);
                PlayerPrefs.SetString("CFname 5", name);
            }
        }
        PlayerPrefs.Save();
    }
    public void loadScene(string sceneName)
    {
        DontDestroyOnLoad(audio);
        SceneManager.LoadScene(sceneName);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void showQuitPrompt()
    {
        quitPrompt.SetActive(true);
    }
    public void closeQuitPromt()
    {
        quitPrompt.SetActive(false);
    }
    public void showCredits()
    {
        creditsPanel.SetActive(true);
    }
    public void closeCredits()
    {
        creditsPanel.SetActive(false);
    }
    public void showResetPanel()
    {
        resetPanel.SetActive(true);
    }
    public void closeResetPanel()
    {
        resetPanel.SetActive(false);
    }
    public void resetGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainMenu");
    }
}
