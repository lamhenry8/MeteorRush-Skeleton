using UnityEngine;
using UnityEngine.Audio;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float screenEdgeY = 6f;
    [SerializeField] private float screenEdgeX = 4f;

    private Vector2 moveDirection;

    public AudioSource audioSource;
    public AudioClip explosionClip;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector2 targetPosition = player.transform.position;
            Vector2 currentPosition = transform.position;
            moveDirection = (targetPosition - currentPosition).normalized;
        }
        else
        {
            moveDirection = Vector2.up;
        }
    }

    void Update()
    {
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;

        if (transform.position.y > screenEdgeY || transform.position.y < -screenEdgeY ||
            transform.position.x > screenEdgeX || transform.position.x < -screenEdgeX)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(playerHealth.currentHealth);
            }

            Destroy(gameObject, explosionClip != null ? explosionClip.length : 0f);
        }
    }
}
