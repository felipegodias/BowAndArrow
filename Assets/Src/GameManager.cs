﻿using System.Collections;

using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameOverScreen m_gameOverScreen;

    private AudioManager m_audioManager;

    public int StartArrows;

    public int StartHealth;

    public int CurrentScore { get; private set; }

    public int Highscore
    {
        get { return PlayerPrefs.GetInt("highscore", 0); }
        private set { PlayerPrefs.SetInt("highscore", value); }
    }

    public int ArrowCount { get; private set; }

    public int Health { get; private set; }

    public bool GameOver { get; private set; }

    public bool HasStarted { get; private set; }

    public bool IsPlaying
    {
        get { return HasStarted && !GameOver; }
    }

    private void Awake()
    {
        m_audioManager = FindObjectOfType<AudioManager>();
        CurrentScore = 0;
        ArrowCount = StartArrows;
        Health = StartHealth;
    }

    public void StartGame()
    {
        m_audioManager.Speak(0, $"{ArrowCount} arrows left.");
        HasStarted = true;
    }

    public void OnBunnyHit(Bunny bunny)
    {
        Health -= 1;
        if (Health == 0) { OnGameOver(); }
    }

    public void OnBunnyDied(Bunny bunny)
    {
        CurrentScore += 50;
    }

    public void OnArrowFired()
    {
        ArrowCount--;
        switch (ArrowCount) {
            case 5:
                m_audioManager.Speak(0, $"{ArrowCount} arrows left.");
                break;
            case 1:
                m_audioManager.Speak(0, "1 arrow left.");
                break;
            case 0:
                m_audioManager.Speak(0, $"No arrows left.");
                break;
        }
        
        if (ArrowCount == 0) { OnGameOver(); }
    }

    private void OnGameOver()
    {
        GameOver = true;
        StartCoroutine(DoGameOver());
    }

    private IEnumerator DoGameOver()
    {
        yield return new WaitForSeconds(3);
        if (CurrentScore > Highscore)
        {
            Highscore = CurrentScore;
            m_audioManager.Play("highscore");
            m_audioManager.Speak(1500, $"New HighScore! Your Score was {CurrentScore}.");
        }
        else
        {
            m_audioManager.Speak(1500, $"Your Score was {CurrentScore}.");
        }

        m_audioManager.Play("gameover");

        m_gameOverScreen.gameObject.SetActive(true);
    }

}