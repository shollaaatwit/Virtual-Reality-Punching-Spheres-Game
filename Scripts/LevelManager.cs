using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public AudioSource currentSong;
    public AudioSource loseSound;
    public AudioSource winSound;
    public GameObject endUI;
    public TextMeshProUGUI messageEnd;

    public bool gameState = true;

    void Start()
    {
        gameState = true;
        endUI.SetActive(false);
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    public void LostGame()
    {
        messageEnd.text = "You lost!";
        gameState = false;
        currentSong.Stop();
        loseSound.Play();
        EndGameUI();
    }

    public void WonGame()
    {
        messageEnd.text = "You passed the level!";
        gameState = false;
        winSound.Play();
        EndGameUI();
    }

    public void EndGameUI()
    {
        endUI.SetActive(true);
    }

    void Update()
    {
        if(scoreManager.scoreNumber < 0 && gameState)
        {
            LostGame();    
        }
        else if(!currentSong.isPlaying && gameState)
        {
            WonGame();
        }

    }
}
