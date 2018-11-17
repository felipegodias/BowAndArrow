﻿using UnityEngine;

public class Bunny : MonoBehaviour
{

    [SerializeField]
    private float m_speed;

    [SerializeField]
    private ParticleSystem m_bloodSplash;

    private void Update()
    {
        transform.position += transform.up * m_speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.GetComponent<Arrow>() == null) { return; }

        if (m_bloodSplash != null) { Instantiate(m_bloodSplash, transform.position, Quaternion.identity); }

        Destroy(gameObject);
    }

}