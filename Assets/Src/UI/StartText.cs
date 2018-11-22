using UnityEngine;

public class StartText : MonoBehaviour
{

    private GameManager m_gameManager;
    private AudioManager m_audioManager;

    private void Awake()
    {
        m_gameManager = FindObjectOfType<GameManager>();
        m_audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (!Input.anyKeyDown) { return; }

        m_audioManager.Play("gamestart");
        m_gameManager.StartGame();
        gameObject.SetActive(false);
    }

}