using UnityEngine;

public class Arrow : MonoBehaviour
{

    [SerializeField]
    private float m_speed;

    private void Update()
    {
        transform.position += transform.right * m_speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}