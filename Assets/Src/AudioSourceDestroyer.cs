using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceDestroyer : MonoBehaviour
{

    private AudioSource m_audioSource;

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    private void LateUpdate()
    {
        if (!m_audioSource.isPlaying) { Destroy(gameObject); }
    }

}