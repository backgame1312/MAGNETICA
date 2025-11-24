using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, destroyTime);

        // 왼쪽으로 이동
        rb.linearVelocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().Die();
        }
    }
}
