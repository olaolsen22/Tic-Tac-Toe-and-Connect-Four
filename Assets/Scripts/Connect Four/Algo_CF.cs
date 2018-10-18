using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Algo_CF : MonoBehaviour {

    public GameController gameController;
    public GameObject cpuController, winningSound;
    public GameObject[] triggers = new GameObject[7];


    public ParticleSystem[] particles0 = new ParticleSystem[7];
    public ParticleSystem[] particles1 = new ParticleSystem[7];
    public ParticleSystem[] particles2 = new ParticleSystem[7];
    public ParticleSystem[] particles3 = new ParticleSystem[7];
    public ParticleSystem[] particles4 = new ParticleSystem[7];
    public ParticleSystem[] particles5 = new ParticleSystem[7];
    
    public Text debug;
    
    int[,] board = new int[6, 7];
    int tieCounter = 0;
    bool makeRandomMove;

    public void updateBoard(int x, int y, int player)
    {
        makeRandomMove = true;
        stopEmitters();
        int[] values = {x,y};
        startEmitters(values);

        if (!gameController.isWinner())
        {
            if (!gameController.enabledAI)
            {
                board[x, y] = player;
                checkWinner(player);
            }
            else
            {
                Debug.Log("Player: " + player);
                board[x, y] = player;
                checkWinner(player);
                
                if (player != 2)
                {
                    StartCoroutine("CPUmove");
                }
            }
            
        }
    }
    void checkWinner(int player)
    {
        tieCounter++;
        //Horizontal
        for (int x = 0; x < 6; x++)  
        {
            for (int y = 0; y < 4; y++) 
            {
                if (board[x, y] == player && board[x, y + 1] == player && board[x, y + 2] == player && board[x, y + 3] == player)
                {
                    declareWinner(player);
                    winningMovePasser(x, y);
                    winningMovePasser(x, y+1);
                    winningMovePasser(x, y+2);
                    winningMovePasser(x, y+3);

                    Instantiate(winningSound);
                    return;
                }
            }
        }
        //Vertical
        for (int y = 0; y < 7; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (board[x, y] == player && board[x + 1, y] == player && board[x + 2, y] == player && board[x + 3, y] == player)
                {
                    declareWinner(player);
                    winningMovePasser(x, y);
                    winningMovePasser(x+1, y);
                    winningMovePasser(x+2, y);
                    winningMovePasser(x+3, y);

                    Instantiate(winningSound);
                    return;
                }
            }
        }
        // /
        for (int y = 0; y < 4; y++)
        {
            for (int x = 5; x > 2; x--)
            {
                if (board[x, y] == player && board[x -1, y + 1] == player && board[x - 2, y + 2] == player && board[x - 3, y + 3] == player)
                {
                    declareWinner(player);
                    winningMovePasser(x, y);
                    winningMovePasser(x - 1, y + 1);
                    winningMovePasser(x - 2, y + 2);
                    winningMovePasser(x - 3, y + 3);

                    Instantiate(winningSound);
                    return;
                }
            }
        }
        // \
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (board[x, y] == player && board[x + 1, y + 1] == player && board[x + 2, y + 2] == player && board[x + 3, y + 3] == player)
                {
                    declareWinner(player);
                    winningMovePasser(x, y);
                    winningMovePasser(x + 1, y + 1);
                    winningMovePasser(x + 2, y + 2);
                    winningMovePasser(x + 3, y + 3);

                    Instantiate(winningSound);
                    return;
                }
            }
        }
        if (tieCounter == 42)
        {

            Instantiate(winningSound);
            declareWinner(0);
            winningMovePasser(0, 0);
            winningMovePasser(0, 1);
            winningMovePasser(0, 2);
            winningMovePasser(0, 3);
            winningMovePasser(0, 4);
            winningMovePasser(0, 5);
            winningMovePasser(0, 6);
            winningMovePasser(1, 0);
            winningMovePasser(1, 1);
            winningMovePasser(1, 2);
            winningMovePasser(1, 3);
            winningMovePasser(1, 4);
            winningMovePasser(1, 5);
            winningMovePasser(1, 6);
            winningMovePasser(2, 0);
            winningMovePasser(2, 1);
            winningMovePasser(2, 2);
            winningMovePasser(2, 3);
            winningMovePasser(2, 4);
            winningMovePasser(2, 5);
            winningMovePasser(2, 6);
            winningMovePasser(3, 0);
            winningMovePasser(3, 1);
            winningMovePasser(3, 2);
            winningMovePasser(3, 3);
            winningMovePasser(3, 4);
            winningMovePasser(3, 5);
            winningMovePasser(3, 6);
            winningMovePasser(4, 0);
            winningMovePasser(4, 1);
            winningMovePasser(4, 2);
            winningMovePasser(4, 3);
            winningMovePasser(4, 4);
            winningMovePasser(4, 5);
            winningMovePasser(4, 6);
            winningMovePasser(5, 0);
            winningMovePasser(5, 1);
            winningMovePasser(5, 2);
            winningMovePasser(5, 3);
            winningMovePasser(5, 4);
            winningMovePasser(5, 5);
            winningMovePasser(5, 6);
        }

    }
    void declareWinner(int player)
    {
        gameController.addScore(player);
        board = new int[6, 7];
        tieCounter = 0;
    }
    void cpuMove()
    {
        // /
        for (int y = 0; y < 4; y++)
        {
            for (int x = 5; x > 2; x--)
            {
                if (board[x, y] == 1 && board[x - 1, y + 1] == 1 && board[x - 2, y + 2] == 1 && board[x - 3, y + 3] == 0)
                {
                    if (x < 5)
                    {
                        if (board[x + 1, y + 3] != 0)
                        {
                            Instantiate(cpuController, triggers[y + 3].transform.position, Quaternion.Euler(0, 0, 0));
                            return;
                        }
                    }
                    else
                    {
                        Instantiate(cpuController, triggers[y + 3].transform.position, Quaternion.Euler(0, 0, 0));
                        return;
                    }
                }
                if (board[x, y] == 0 && board[x - 1, y + 1] == 1 && board[x - 2, y + 2] == 1 && board[x - 3, y + 3] == 1)
                {
                    if (x < 5)
                    {
                        if (board[x+1, y] != 0)
                        {
                            Instantiate(cpuController, triggers[y].transform.position, Quaternion.Euler(0, 0, 0));
                            return;
                        }
                    }
                    else
                    {
                        Instantiate(cpuController, triggers[y].transform.position, Quaternion.Euler(0, 0, 0));
                        return;
                    }

                }
            }
        }
        // \
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (board[x, y] == 1 && board[x + 1, y + 1] == 1 && board[x + 2, y + 2] == 1 && board[x + 3, y + 3] == 0)
                {
                    if (x < 2)
                    {
                        if (board[x + 4, y + 3] != 0)
                        {
                            Instantiate(cpuController, triggers[y + 3].transform.position, Quaternion.Euler(0, 0, 0));
                            return;
                        }
                    }
                    else
                    {
                        Instantiate(cpuController, triggers[y + 3].transform.position, Quaternion.Euler(0, 0, 0));
                        return;
                    }
                }
                if (board[x, y] == 0 && board[x + 1, y + 1] == 1 && board[x + 2, y + 2] == 1 && board[x + 3, y + 3] == 1)
                {
                    if (x < 3)
                    {
                        if (board[x+1, y] != 0)
                        {
                            Instantiate(cpuController, triggers[y].transform.position, Quaternion.Euler(0, 0, 0));
                            return;
                        }
                    }
                }
            }
        }
        //Vertical
        for (int y = 0; y < 7; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                //Normal
                if (board[x, y] == 0 && board[x + 1, y] == 1 && board[x + 2, y] == 1 && board[x + 3, y] == 1)
                {
                    Instantiate(cpuController, triggers[y].transform.position, Quaternion.Euler(0, 0, 0));
                    return;
                }
                if (board[x+1, y] == 0 && board[x + 2, y] == 1 && board[x + 3, y] == 1)
                {
                    Instantiate(cpuController, triggers[y].transform.position, Quaternion.Euler(0, 0, 0));
                    return;
                }
            }
        }
        //Horizontal
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                if (board[x, y] == 1 && board[x, y + 1] == 1 && board[x, y + 2] == 1 && board[x, y + 3] == 0)
                {
                    if(x < 5)
                    {
                        if (board[x + 1, y + 3] != 0)
                        {
                            Instantiate(cpuController, triggers[y + 3].transform.position, Quaternion.Euler(0, 0, 0));
                            return;
                        }
                    }
                    else
                    {
                        Instantiate(cpuController, triggers[y + 3].transform.position, Quaternion.Euler(0, 0, 0));
                        return;
                    }
                }
                if (board[x, y] == 0 && board[x, y + 1] == 1 && board[x, y + 2] == 1 && board[x, y + 3] == 1)
                {
                    if (x < 5)
                    {
                        if (board[x + 1, y + 3] != 0)
                        {
                            Instantiate(cpuController, triggers[y].transform.position, Quaternion.Euler(0, 0, 0));
                            return;
                        }
                    }
                    else
                    {
                        Instantiate(cpuController, triggers[y].transform.position, Quaternion.Euler(0, 0, 0));
                        return;
                    }
                }
                if (board[x, y] == 1 && board[x, y + 1] == 1 && board[x, y + 2] == 0)
                {
                    if (x < 5)
                    {
                        if (board[x + 1, y + 2] != 0)
                        {
                            Instantiate(cpuController, triggers[y + 2].transform.position, Quaternion.Euler(0, 0, 0));
                            return;
                        }
                    }
                    else
                    {
                        Instantiate(cpuController, triggers[y + 2].transform.position, Quaternion.Euler(0, 0, 0));
                        return;
                    }
                }
                if (board[x, y] == 0 && board[x, y + 1] == 1 && board[x, y + 2] == 1)
                {
                    if (x < 5 && y > 0)
                    {
                        if (board[x + 1, y-1] != 0)
                        {
                            Instantiate(cpuController, triggers[y].transform.position, Quaternion.Euler(0, 0, 0));
                            return;
                        }
                    }
                    else
                    {
                        Instantiate(cpuController, triggers[y].transform.position, Quaternion.Euler(0, 0, 0));
                        return;
                    }
                }
                if (board[x, y] == 1 && board[x, y + 1] == 1 && board[x, y + 2] == 0 && board[x, y + 3] == 1)
                {
                    if (x < 5)
                    {
                        if (board[x + 1, y + 2] != 0)
                        {
                            Instantiate(cpuController, triggers[y + 2].transform.position, Quaternion.Euler(0, 0, 0));
                            return;
                        }
                    }
                    else
                    {
                        Instantiate(cpuController, triggers[y + 2].transform.position, Quaternion.Euler(0, 0, 0));
                        return;
                    }
                }
                if (board[x, y] == 1 && board[x, y + 1] == 0 && board[x, y + 2] == 1 && board[x, y + 3] == 1)
                {
                    if (x < 5)
                    {
                        if (board[x + 1, y + 1] != 0)
                        {
                            Instantiate(cpuController, triggers[y + 1].transform.position, Quaternion.Euler(0, 0, 0));
                            return;
                        }
                    }
                    else
                    {
                        Instantiate(cpuController, triggers[y + 2].transform.position, Quaternion.Euler(0, 0, 0));
                        return;
                    }
                }
                if (board[x, y] == 1 && board[x, y + 1] == 1 && board[x, y + 2] == 1 && board[x, y + 3] == 1)
                {
                    if (x < 5 && y > 0)
                    {
                        if (board[x + 1, y + 1] != 0)
                        {
                            Instantiate(cpuController, triggers[y+1].transform.position, Quaternion.Euler(0, 0, 0));
                            return;
                        }
                    }
                    else
                    {
                        Instantiate(cpuController, triggers[y].transform.position, Quaternion.Euler(0, 0, 0));
                        return;
                    }
                }

            }
        }
        if(makeRandomMove)
            randomCPUmove();
        return;
    }
    void randomCPUmove()
    {
        Debug.Log("Random Move");
        int random = Random.Range(0, 6);
        for (int x = 0; x < 6; x++)
        {
            if (board[x, random] == 0)
            {
                Instantiate(cpuController, triggers[random].transform.position, Quaternion.Euler(0, 0, 0));
                return;
            }
        }
    }
    void startEmitters(int[] value)
    {
        switch (value[0])
        {
            case 0:
                particles0[value[1]].Play();
                break;
            case 1:
                particles1[value[1]].Play();
                break;
            case 2:
                particles2[value[1]].Play();
                break;
            case 3:
                particles3[value[1]].Play();
                break;
            case 4:
                particles4[value[1]].Play();
                break;
            case 5:
                particles5[value[1]].Play();
                break;
        }
    }
    public void stopEmitters()
    {
        for (int i = 0; i < 7; i++)
        {
            particles0[i].Stop();
            particles1[i].Stop();
            particles2[i].Stop();
            particles3[i].Stop();
            particles4[i].Stop();
            particles5[i].Stop();
        }
        GameObject[] audio = GameObject.FindGameObjectsWithTag("Winning SFX");
        for (int i = 0; i < audio.Length; i++)
        {
            Destroy(audio[i]);
        }
    }
    void winningMovePasser(int x, int y)
    {
        int[] value = { x, y };
        StartCoroutine("WinningMove",value);
    }
    IEnumerator WinningMove(int[] valuesXY)
    {
        yield return new WaitForSeconds(0f);
        makeRandomMove = false;
        yield return new WaitForSeconds(0.25f);
        startEmitters(valuesXY);
        yield return new WaitForSeconds(3f);
        stopEmitters();
    }
    IEnumerator CPUmove()
    {
        yield return new WaitForSeconds(0.25f);
            cpuMove();
        yield return new WaitForSeconds(0.25f);
        Destroy(GameObject.FindGameObjectWithTag("AI Controller"));
        //Destroy(GameObject.FindGameObjectWithTag("Board Blocker"));
    }
}
