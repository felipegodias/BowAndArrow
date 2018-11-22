using UnityEngine;

public class StartText : MonoBehaviour
{

    private GameManager m_gameManager;

    private void Awake()
    {
        m_gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (!Input.anyKeyDown) { return; }

        m_gameManager.StartGame();
        gameObject.SetActive(false);
    }

}