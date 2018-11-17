using System.Text;

using UnityEngine;
using UnityEngine.UI;

public class ArrowCountText : MonoBehaviour
{

    private Text m_text;

    private GameManager m_gameManager;

    private int m_lastCount;

    private void Awake()
    {
        m_gameManager = FindObjectOfType<GameManager>();
        m_text = GetComponent<Text>();
    }

    private void Update()
    {
        if (m_lastCount == m_gameManager.ArrowCount) { return; }

        m_lastCount = m_gameManager.ArrowCount;
        var buffer = new StringBuilder();
        buffer.Append('↑', m_lastCount);
        m_text.text = buffer.ToString();
    }

}