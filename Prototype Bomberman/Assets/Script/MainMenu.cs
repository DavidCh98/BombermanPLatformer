﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject playAgainUI;
    public GameObject player1;
    public GameObject player2;
    public GameObject Winplayer1;
    public GameObject Winplayer2;

        private void Start() 
    {
        player1 = GameObject.Find("CharacterA");
        player2 = GameObject.Find("CharacterB");
    }

    public void PlayGame(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UIClick");
        SceneManager.LoadScene("Game");
    }
    public void PlayGameFirst(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UIClick");
        SceneManager.LoadScene("Controls");
    }
     public void ShowControls(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UIClick");
        SceneManager.LoadScene("ControlsShowOnly");
    }

    public void GoMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log("You quited");
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UIClick");
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
          if (player1 == null) 
        { 
            Winplayer2.GetComponent<Image>().enabled = true;
            playAgainUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (player2 == null) 
        { 
            Winplayer1.GetComponent<Image>().enabled = true;
            playAgainUI.SetActive(true);
            Time.timeScale = 0f;
        } 
    }
    public void Resume(){
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UIClick");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
