using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float m_moveableHeight;

    [SerializeField]
    private float m_speed;

    [SerializeField]
    private float m_damp;

    [SerializeField]
    private Transform m_arrowStartPosition;

    [SerializeField]
    private Arrow m_arrowPrefab;

    [SerializeField]
    private float m_shootDelay;

    private Animator m_animator;

    private float m_y;

    private float m_currentShootDelay;

    private GameManager m_gameManager;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_currentShootDelay = m_shootDelay;
        m_gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (m_gameManager.GameOver) { return; }

        HandleMove();
        HandleShoot();
    }

    private void HandleMove()
    {
        float moveInput = Input.GetAxis("Vertical");

        float y = transform.position.y;
        y += moveInput * m_speed;
        y = Mathf.Clamp(y, -m_moveableHeight / 2, m_moveableHeight / 2);
        m_y = Mathf.Lerp(m_y, y, Time.deltaTime * m_damp);

        transform.position = new Vector3(transform.position.x, m_y, transform.position.z);
    }

    private void HandleShoot()
    {
        m_currentShootDelay -= Time.deltaTime;
        if (m_currentShootDelay > 0) { return; }

        bool shoot = Input.GetButtonDown("Fire1");
        if (!shoot) { return; }

        m_animator.SetTrigger("Shoot");
        m_currentShootDelay = m_shootDelay;
        m_gameManager.OnArrowFired();
        Instantiate(m_arrowPrefab, m_arrowStartPosition.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        var center = new Vector3(transform.position.x + 0.15f, 0, 0);
        var size = new Vector3(0.25f, m_moveableHeight, 0);

        Gizmos.DrawWireCube(center, size);
    }

}