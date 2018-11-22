using UnityEngine;

public class Instantiator : MonoBehaviour
{

    [SerializeField]
    private float m_delay;

    [SerializeField]
    private Bunny m_bunnyPrefab;

    private GameManager m_gameManager;

    private AudioManager m_audioManager;

    private float m_currentDelay;

    private void Awake()
    {
        m_gameManager = FindObjectOfType<GameManager>();
        m_audioManager = FindObjectOfType<AudioManager>();
        m_currentDelay = 1;
    }

    private void Update()
    {
        if (!m_gameManager.IsPlaying) { return; }

        m_currentDelay -= Time.deltaTime;
        if (m_currentDelay > 0) { return; }

        m_currentDelay = m_delay;

        int count = Random.Range(1, 8);
        float offset = Random.Range(0f, 2f);

        string plural = count == 1 ? "" : "s";
        m_audioManager.Speak(0, $"{count} rabbit{plural} incoming.");
        for (var i = 0; i < count; i++)
        {
            Instantiate(m_bunnyPrefab, new Vector3(offset + -0.75f + i * 0.15f, -1.5f, 0), Quaternion.identity);
        }
    }

}