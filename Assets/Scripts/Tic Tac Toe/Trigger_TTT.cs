using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_TTT : MonoBehaviour {

	public GameController gameController;
    public Algo_TTT algorithm;
    public int x, y;
	public GameObject clickBlocker, player1Model, player2Model;

    void OnTriggerEnter(Collider other)
    {
        run();
    }

    void OnMouseDown()
	{
        Debug.Log("Triggered");
        run();
    }

    void run()
    {
        if (gameController.getPlayerTurn() == 1)
        {            
            spawnPlayer(player1Model, 1);
            gameController.setPlayerTurn(2);
        }
        else
        {
            spawnPlayer(player2Model, 2);
            gameController.setPlayerTurn(1);
        }
    }

    void spawnPlayer(GameObject playerModel, int playerTurn)
    {
        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(playerTurn);
        algorithm.updateBoard(x, y, playerTurn);
        Vector3 spawnLocation = this.transform.position;

        Instantiate(clickBlocker, spawnLocation, Quaternion.Euler(0, 0, 0));
        
        spawnLocation.y = 5;
        spawnLocation.z -= 1.5f;

        Instantiate(playerModel, spawnLocation, Quaternion.Euler(90,0,0));
    }

}