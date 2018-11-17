using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{

    private ParticleSystem m_particleSystem;

    private void Awake()
    {
        m_particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!m_particleSystem.IsAlive(true)) { Destroy(gameObject); }
    }

}