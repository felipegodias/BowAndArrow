﻿using UnityEngine;

public class Instantiator : MonoBehaviour
{

    [SerializeField]
    private float m_delay;

    [SerializeField]
    private Bunny m_bunnyPrefab;

    private float m_currentDelay;

    private void Awake()
    {
        m_currentDelay = m_delay;
    }

    private void Update()
    {
        m_currentDelay -= Time.deltaTime;
        if (m_currentDelay > 0) { return; }

        m_currentDelay = m_delay;

        int count = Random.Range(1, 8);
        float offset = Random.Range(0f, 2f);

        for (int i = 0; i < count; i++)
        {
            Instantiate(m_bunnyPrefab, new Vector3(offset + -0.75f + i * 0.15f, -1.5f, 0), Quaternion.identity);
        }
    }

}