﻿using UnityEngine;

public class Bunny : MonoBehaviour
{

    [SerializeField]
    private float m_speed;

    [SerializeField]
    private ParticleSystem m_bloodSplash;

    private GameManager m_gameManager;

    private AudioManager m_audioManager;

    private float m_lifeTime;

    private void Awake()
    {
        m_gameManager = FindObjectOfType<GameManager>();
        m_audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        transform.position += transform.up * m_speed * Time.deltaTime;
        m_lifeTime += Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (m_lifeTime > 20) { Destroy(gameObject); }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.GetComponent<Arrow>() == null) { return; }

        if (m_bloodSplash != null) { Instantiate(m_bloodSplash, transform.position, Quaternion.identity); }

        m_gameManager.OnBunnyDied(this);
        m_audioManager.Play("hit");
        Destroy(gameObject);
    }

}