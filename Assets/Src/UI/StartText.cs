using System.Collections;

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

    public IEnumerator Start()
    {
        while (!m_gameManager.HasStarted)
        {
            m_audioManager.Speak(200, "Press any button to start.");
            yield return new WaitForSeconds(5);
        }
    }

    private void Update()
    {
        if (!Input.anyKeyDown) { return; }

        m_audioManager.Play("gamestart");
        m_gameManager.StartGame();
        gameObject.SetActive(false);
    }

}