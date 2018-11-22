using System.Linq;

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ProximitySensor : MonoBehaviour
{

    private AudioSource m_audioSource;

    private Player m_player;

    private GameManager m_gameManager;

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();

        m_player = FindObjectOfType<Player>();
        m_gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (m_gameManager.IsPlaying)
        {
            if (!m_audioSource.isPlaying) { m_audioSource.Play(); }
        }
        else
        {
            m_audioSource.Pause();
            return;
        }

        Bunny[] bunnies = FindObjectsOfType<Bunny>();
        float py = m_player.transform.position.y - 0.25f;
        float closest =
            (from bunny in bunnies
                select bunny.transform.position.y
                into @by
                where !(@by > py)
                select Mathf.Abs(py - @by)).Concat(new[] { float.MaxValue }).Min();

        m_audioSource.pitch = Mathf.Clamp01(1 - closest) * 1.5f;
    }

}