using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

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

    private void Awake()
    {
        CurrentScore = 0;
        ArrowCount = StartArrows;
        Health = StartHealth;
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
        if (ArrowCount == 0) { OnGameOver(); }
    }

    private void OnGameOver()
    {
        GameOver = true;
        if (CurrentScore > Highscore) { Highscore = CurrentScore; }
        SceneManager.LoadScene("game");
    }

}