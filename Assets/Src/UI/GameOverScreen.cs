using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    [SerializeField]
    private Text m_highscoreText;

    [SerializeField]
    private Text m_scoreText;

    private GameManager m_gameManager;

    private void Awake()
    {
        m_gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        m_highscoreText.text = m_gameManager.Highscore.ToString("N0");
        m_scoreText.text = m_gameManager.CurrentScore.ToString("N0");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) { SceneManager.LoadScene("Game"); }
    }

}