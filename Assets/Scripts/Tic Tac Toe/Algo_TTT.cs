using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Algo_TTT : MonoBehaviour {

    public GameController gameController;
    public GameObject[] triggers = new GameObject[9];
    public GameObject cpuController, boardBlocker, winningSound;
    public ParticleSystem winningStars;
    
    int[,] board = new int[3,3];
    int tieCounter = 0;
    bool winningMove = false;

    public void updateBoard(int x, int y, int player)
    {
        winningMove = false;
        if (!gameController.isWinner())
        {
            if (!gameController.enabledAI)
                board[x, y] = player;
            else
            {
                board[x, y] = player;
                if (player == 1)
                {
                    Instantiate(boardBlocker);
                    if(tieCounter != 8)
                        StartCoroutine("CPUmove", player);
                }
            }
            checkWinner(player);
        }
    }
    void checkWinner(int player)
    {
        tieCounter++;
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) //Horizontal
            {
                winningMove = true;
                glowWinningMove(i, 0);
                glowWinningMove(i, 1);
                glowWinningMove(i, 2);
                Instantiate(winningSound);
                declareWinner(player);
            }
            else if (board[0, i] == player && board[1, i] == player && board[2, i] == player) //Vertical
            {
                winningMove = true;
                glowWinningMove(0, i);
                glowWinningMove(1, i);
                glowWinningMove(2, i);
                Instantiate(winningSound);

                declareWinner(player);
            }
            else if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) // Diagonal
            {
                winningMove = true;
                glowWinningMove(0, 0);
                glowWinningMove(1, 1);
                glowWinningMove(2, 2);
                Instantiate(winningSound);

                declareWinner(player);
                break;
            }
            else if  (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                winningMove = true;
                glowWinningMove(0, 2);
                glowWinningMove(1, 1);
                glowWinningMove(2, 0);
                Instantiate(winningSound);

                declareWinner(player);
                break;
            }
            else if (tieCounter == 9)
            {
                glowWinningMove(0, 0);
                glowWinningMove(0, 1);
                glowWinningMove(0, 2);
                glowWinningMove(1, 0);
                glowWinningMove(1, 1);
                glowWinningMove(1, 2);
                glowWinningMove(2, 0);
                glowWinningMove(2, 1);
                glowWinningMove(2, 2);
                Instantiate(winningSound);

                declareWinner(0);
            }
        }
    }
    void glowWinningMove(int x, int y)
    {
        if(x == 0 && y == 0)
        {
            Instantiate(winningStars, triggers[0].transform.position, Quaternion.Euler(-90, 0, 0));
        }
        else if (x == 0 && y == 1)
        {
            Instantiate(winningStars, triggers[1].transform.position, Quaternion.Euler(-90, 0, 0));
        }
        else if (x == 0 && y == 2)
        {
            Instantiate(winningStars, triggers[2].transform.position, Quaternion.Euler(-90, 0, 0));
        }
        else if (x == 1 && y == 0)
        {
            Instantiate(winningStars, triggers[3].transform.position, Quaternion.Euler(-90, 0, 0));
        }
        else if (x == 1 && y == 1)
        {
            Instantiate(winningStars, triggers[4].transform.position, Quaternion.Euler(-90, 0, 0));
        }
        else if (x == 1 && y == 2)
        {
            Instantiate(winningStars, triggers[5].transform.position, Quaternion.Euler(-90, 0, 0));
        }
        else if (x == 2 && y == 0)
        {
            Instantiate(winningStars, triggers[6].transform.position, Quaternion.Euler(-90, 0, 0));
        }
        else if (x == 2 && y == 1)
        {
            Instantiate(winningStars, triggers[7].transform.position, Quaternion.Euler(-90, 0, 0));
        }
        else if (x == 2 && y == 2)
        {
            Instantiate(winningStars, triggers[8].transform.position, Quaternion.Euler(-90, 0, 0));
        }
        StartCoroutine("KillAudio");
    }
    void declareWinner(int player)
    {
        gameController.addScore(player);
        board = new int[3, 3];
        tieCounter = 0;
    }
    void cpuMove()
    {
        if (!winningMove) {
            if (board[1, 1] == 0)
            {
                Instantiate(cpuController, triggers[4].transform.position, Quaternion.Euler(0, 0, 0));
                Debug.Log("Executed");
            }
            else
            {
                //**********************************************************************************************
                //***************************************** FTW ************************************************
                //**********************************************************************************************

                //**************************************HORIZONTAL**********************************************

                if (board[0, 0] == 2 && board[0, 1] == 2 && board[0, 2] == 0)
                    Instantiate(cpuController, triggers[2].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[1, 0] == 2 && board[1, 1] == 2 && board[1, 2] == 0)
                    Instantiate(cpuController, triggers[5].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[2, 0] == 2 && board[2, 1] == 2 && board[2, 2] == 0)
                    Instantiate(cpuController, triggers[8].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 1] == 2 && board[0, 2] == 2 && board[0, 0] == 0)
                    Instantiate(cpuController, triggers[0].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[1, 1] == 2 && board[1, 2] == 2 && board[1, 0] == 0)
                    Instantiate(cpuController, triggers[3].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[2, 1] == 2 && board[2, 2] == 2 && board[2, 0] == 0)
                    Instantiate(cpuController, triggers[6].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 0] == 2 && board[0, 1] == 0 && board[0, 2] == 2)
                    Instantiate(cpuController, triggers[1].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[1, 0] == 2 && board[1, 1] == 0 && board[1, 2] == 2)
                    Instantiate(cpuController, triggers[4].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[2, 0] == 2 && board[2, 1] == 0 && board[2, 2] == 2)
                    Instantiate(cpuController, triggers[7].transform.position, Quaternion.Euler(0, 0, 0));


                //****************************************VERTICAL**********************************************

                else if (board[0, 0] == 2 && board[1, 0] == 2 && board[2, 0] == 0) //Vertical
                    Instantiate(cpuController, triggers[6].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 1] == 2 && board[1, 1] == 2 && board[2, 1] == 0) //Vertical
                    Instantiate(cpuController, triggers[7].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 2] == 2 && board[1, 2] == 2 && board[2, 2] == 0) //Vertical
                    Instantiate(cpuController, triggers[8].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 0] == 0 && board[1, 0] == 2 && board[2, 0] == 2) //Vertical
                    Instantiate(cpuController, triggers[0].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 1] == 0 && board[1, 1] == 2 && board[2, 1] == 2) //Vertical
                    Instantiate(cpuController, triggers[1].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 2] == 0 && board[1, 2] == 2 && board[2, 2] == 2) //Vertical
                    Instantiate(cpuController, triggers[2].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 0] == 2 && board[1, 0] == 0 && board[2, 0] == 2) //Vertical
                    Instantiate(cpuController, triggers[3].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 1] == 2 && board[1, 1] == 0 && board[2, 1] == 2) //Vertical
                    Instantiate(cpuController, triggers[4].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 2] == 2 && board[1, 2] == 0 && board[2, 2] == 2) //Vertical
                    Instantiate(cpuController, triggers[5].transform.position, Quaternion.Euler(0, 0, 0));


                //****************************************DIAGONAL**********************************************

                else if (board[0, 0] == 2 && board[1, 1] == 2 && board[2, 2] == 0)
                    Instantiate(cpuController, triggers[8].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 0] == 2 && board[1, 1] == 0 && board[2, 2] == 2)
                    Instantiate(cpuController, triggers[4].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 0] == 0 && board[1, 1] == 2 && board[2, 2] == 2)
                    Instantiate(cpuController, triggers[0].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 2] == 0 && board[1, 1] == 2 && board[2, 0] == 2)
                    Instantiate(cpuController, triggers[2].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 2] == 2 && board[1, 1] == 0 && board[2, 0] == 2)
                    Instantiate(cpuController, triggers[4].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 2] == 2 && board[1, 1] == 2 && board[2, 0] == 0)
                    Instantiate(cpuController, triggers[6].transform.position, Quaternion.Euler(0, 0, 0));

                //**********************************************************************************************
                //*************************************  BLOCKERS  *********************************************
                //**********************************************************************************************

                //**************************************HORIZONTAL**********************************************

                else if (board[0, 0] == 1 && board[0, 1] == 1 && board[0, 2] == 0)
                    Instantiate(cpuController, triggers[2].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[1, 0] == 1 && board[1, 1] == 1 && board[1, 2] == 0)
                    Instantiate(cpuController, triggers[5].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[2, 0] == 1 && board[2, 1] == 1 && board[2, 2] == 0)
                    Instantiate(cpuController, triggers[8].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 1] == 1 && board[0, 2] == 1 && board[0, 0] == 0)
                    Instantiate(cpuController, triggers[0].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[1, 1] == 1 && board[1, 2] == 1 && board[1, 0] == 0)
                    Instantiate(cpuController, triggers[3].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[2, 1] == 1 && board[2, 2] == 1 && board[2, 0] == 0)
                    Instantiate(cpuController, triggers[6].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 0] == 1 && board[0, 1] == 0 && board[0, 2] == 1)
                    Instantiate(cpuController, triggers[1].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[1, 0] == 1 && board[1, 1] == 0 && board[1, 2] == 1)
                    Instantiate(cpuController, triggers[4].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[2, 0] == 1 && board[2, 1] == 0 && board[2, 2] == 1)
                    Instantiate(cpuController, triggers[7].transform.position, Quaternion.Euler(0, 0, 0));


                //****************************************VERTICAL**********************************************

                else if (board[0, 0] == 1 && board[1, 0] == 1 && board[2, 0] == 0) //Vertical
                    Instantiate(cpuController, triggers[6].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 1] == 1 && board[1, 1] == 1 && board[2, 1] == 0) //Vertical
                    Instantiate(cpuController, triggers[7].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 2] == 1 && board[1, 2] == 1 && board[2, 2] == 0) //Vertical
                    Instantiate(cpuController, triggers[8].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 0] == 0 && board[1, 0] == 1 && board[2, 0] == 1) //Vertical
                    Instantiate(cpuController, triggers[0].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 1] == 0 && board[1, 1] == 1 && board[2, 1] == 1) //Vertical
                    Instantiate(cpuController, triggers[1].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 2] == 0 && board[1, 2] == 1 && board[2, 2] == 1) //Vertical
                    Instantiate(cpuController, triggers[2].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 0] == 1 && board[1, 0] == 0 && board[2, 0] == 1) //Vertical
                    Instantiate(cpuController, triggers[3].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 1] == 1 && board[1, 1] == 0 && board[2, 1] == 1) //Vertical
                    Instantiate(cpuController, triggers[4].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 2] == 1 && board[1, 2] == 0 && board[2, 2] == 1) //Vertical
                    Instantiate(cpuController, triggers[5].transform.position, Quaternion.Euler(0, 0, 0));


                //****************************************DIAGONAL**********************************************

                else if (board[0, 0] == 1 && board[1, 1] == 1 && board[2, 2] == 0)
                    Instantiate(cpuController, triggers[8].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 0] == 1 && board[1, 1] == 0 && board[2, 2] == 1)
                    Instantiate(cpuController, triggers[4].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 0] == 0 && board[1, 1] == 1 && board[2, 2] == 1)
                    Instantiate(cpuController, triggers[0].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 2] == 0 && board[1, 1] == 1 && board[2, 0] == 1)
                    Instantiate(cpuController, triggers[2].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 2] == 1 && board[1, 1] == 0 && board[2, 0] == 1)
                    Instantiate(cpuController, triggers[4].transform.position, Quaternion.Euler(0, 0, 0));

                else if (board[0, 2] == 1 && board[1, 1] == 1 && board[2, 0] == 0)
                    Instantiate(cpuController, triggers[6].transform.position, Quaternion.Euler(0, 0, 0));

                else //if nothing is good
                {
                    int ctr = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board[i, j] == 0)
                            {
                                Debug.Log(triggers[ctr]);
                                Instantiate(cpuController, triggers[ctr].transform.position, Quaternion.Euler(0, 0, 0));
                                return;
                            }
                            ctr++;
                        }
                    }
                }
            }
        }
    }
    IEnumerator KillAudio()
    {
        yield return new WaitForSeconds(2);
        GameObject[] audio = GameObject.FindGameObjectsWithTag("Winning SFX");
        for (int i = 0; i < audio.Length; i++)
        {
            Destroy(audio[i]);
        }
    }
    IEnumerator CPUmove(int player)
    {
        yield return new WaitForSeconds(0.5f);
        if (!gameController.isWinner())
        {
            cpuMove();
        }
        yield return new WaitForSeconds(0.5f);
            Destroy(GameObject.FindGameObjectWithTag("AI Controller"));
            Destroy(GameObject.FindGameObjectWithTag("Board Blocker"));
    }
}
