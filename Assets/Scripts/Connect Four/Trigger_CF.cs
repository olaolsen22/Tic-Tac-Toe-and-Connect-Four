using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_CF : MonoBehaviour {

    public GameController gameController;
    public GameObject[] triggers = new GameObject[7];
    public GameObject cpuController;
    public Algo_CF algorithm;
    public int x;
    public GameObject clickBlocker, player1Model, player2Model, waitBlocker;

    int y = 5;

    void Update()
    {
        if (gameController.isWinner())
            y = 5;
    }
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
        if (y != -1)
        {
            if (gameController.getPlayerTurn() == 1)
            {
                spawnPlayer(player1Model, 1);
            }
            else
            {
                spawnPlayer(player2Model, 2);
            }
        }
    }
    void spawnPlayer(GameObject playerModel, int playerTurn)
    {
        algorithm.updateBoard(y, x, playerTurn);
        y--;
        Vector3 spawnLocation = this.transform.position, spawnWait = this.transform.position;

        spawnWait.z -= .25f;
        spawnLocation.y = 5;
        spawnLocation.z += .25f;

        if (y != -1)
        {
            Instantiate(waitBlocker, spawnWait, Quaternion.Euler(0, 0, 0));
            StartCoroutine("Wait");
        }
            
        Instantiate(playerModel, spawnLocation, Quaternion.Euler(0, 0, 0));

        if (playerTurn == 1)
            gameController.setPlayerTurn(2);
        else if (playerTurn == 2)
            gameController.setPlayerTurn(1);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.30f);
        Destroy(GameObject.FindGameObjectWithTag("Wait Blocker"));

    }
}