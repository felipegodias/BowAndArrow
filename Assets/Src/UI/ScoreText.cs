using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    private Text m_text;

    private GameManager m_gameManager;

    private void Awake()
    {
        m_gameManager = FindObjectOfType<GameManager>();
        m_text = GetComponent<Text>();
    }

    private void Update()
    {
        m_text.text = m_gameManager.CurrentScore.ToString("N0");
    }

}