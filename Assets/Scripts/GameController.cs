using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    
    public Text player1Score_text, player2Score_text, player1name_text, player2name_text, playerWinner_text, player1_customName;
    public string player1Name, player2Name;
    public GameObject boardBlocker, winnerWindow, playerSelection;
    public Algo_CF connectFour;
    public int seconds;

    public MainMenu mainMenu;

    int player1Score = 1, player2Score = 1, playerTurn = 1;
    bool winner = false;
    
    public void setNamesScore()
    {
        if (!enabledAI)
        {
            player1name_text.text = player1Name;
            player2name_text.text = player2Name;
        }
        else
        {
            player1name_text.text = "";
            player2name_text.text = "CPU";
        }

        player1Score_text.text = "0";
        player2Score_text.text = "0";
    }
    public void setName()  //FOR NAME IN DATABASE*********************************
    {
        if (enabledAI)
        {
            player1name_text.text = player1_customName.text;
        }
    }
    public bool enabledAI { get; set; }
    
    public void addScore(int player) //replace ng replace sa database ksi pag nag reset ung game after winning or sa pause menu, ilload lang ung scene so mawawala ung value ng score
    {
        
        if (player == 1)
        {
            if (enabledAI)
            {
                if (SceneManager.GetActiveScene().name == "TicTacToe")
                {
                    Debug.Log("Valid");
                    mainMenu.updateHighScores("TTT", player1_customName.text, player1Score);
                }
                else if ((SceneManager.GetActiveScene().name == "Connect Four"))
                {
                    mainMenu.updateHighScores("CF", player1_customName.text, player1Score);
                }
            }
            player1Score_text.text = ""+player1Score++;
            setWinner(player1Name);
        }
        else if (player == 2)
        {
            player2Score_text.text = ""+player2Score++;
            setWinner(player2Name);
        }
        else if(player == 0)
            setWinner("TIE");

        
    }
    public void setPlayerTurn(int player)
    {
        playerTurn = player;
    }
    public int getPlayerTurn()
    {
        return playerTurn;
    }
    private void setWinner(string playerName)
    {
        if (playerName != "TIE")
            playerWinner_text.text = playerName + " Wins!";
        else
            playerWinner_text.text = "It's a Tie!";
        Instantiate(boardBlocker);
        StartCoroutine("waitWinnerPopUp");        
    }
    public void nextRound()
    {
        winner = false;
        //playerTurn_text.text = "Turn:\n" + player1Name;
        playerTurn = 1;
        GameObject[] blockers = GameObject.FindGameObjectsWithTag("Player & Blocker");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] boardBlockers = GameObject.FindGameObjectsWithTag("Board Blocker");

        
        
        if (SceneManager.GetActiveScene().name == "Connect Four")
        {
            connectFour.stopEmitters();
        }

        GameObject[] winningParticle = GameObject.FindGameObjectsWithTag("Winning Particle");

        for(int i = 0; i < boardBlockers.Length; i++)
        {
            Destroy(boardBlockers[i]);
        }

        for (int i = 0; i < winningParticle.Length; i++)
        {
            Destroy(winningParticle[i]);
        }
        for (int i = 0; i < blockers.Length; i++)
        {
            Destroy(blockers[i]);
        }
        for (int i = 0; i < players.Length; i++)
        {
            Destroy(players[i]);
        }
        
        winnerWindow.SetActive(false);

    }
    public bool isWinner()
    {
        return winner;
    }
    IEnumerator waitWinnerPopUp()
    {
        yield return new WaitForSeconds(seconds);
        winnerWindow.SetActive(true);
        winner = true;
    }
}
