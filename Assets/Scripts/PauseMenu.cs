using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameController gameController;
    public GameObject pauseMenu, boardBlocker, cameraMenu, playerSelection, quitPrompt, playerNamePrompt;
    public Camera[] cameraViews;

    private void Start()
    {
        changeCamera(0);
        openPlayerSelection();
    }
    public void openPlayerSelection()
    {
        Instantiate(boardBlocker);
        playerSelection.SetActive(true);
    }
    public void closePlayerSelection()
    {
        gameController.setNamesScore();
        Destroy(GameObject.FindGameObjectWithTag("Board Blocker"));
        playerSelection.SetActive(false);
    }
    public void showPlayerName()
    {
        playerNamePrompt.SetActive(true);
        Instantiate(boardBlocker);
    }
    public void closePlayerName()
    {
        playerNamePrompt.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Board Blocker"));
    }
    public void showPauseMenu()
    {
        pauseMenu.SetActive(true);
        Instantiate(boardBlocker);
    }
    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Board Blocker"));
    }
    public void openCameraMenu()
    {
        cameraMenu.SetActive(true);
    }
    public void closeCameraMenu()
    {
        cameraMenu.SetActive(false);
    }
    public void changeCamera (int cameraView)
    {
        for(int i = 0; i < cameraViews.Length; i++)
        {
            if(i != cameraView)
                cameraViews[i].enabled = false;
        }
        cameraViews[cameraView].enabled = true;
    }
}
