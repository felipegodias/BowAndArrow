using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ThemeAudioSource : MonoBehaviour
{

    private AudioSource m_audioSource;

    private GameManager m_gameManager;

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        m_audioSource.volume = Mathf.Lerp(m_audioSource.volume, m_gameManager.HasStarted ? 0 : 1, Time.deltaTime * 3);
    }

}