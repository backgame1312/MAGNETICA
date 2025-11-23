using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 5f;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().Die();
        }
    }
}
