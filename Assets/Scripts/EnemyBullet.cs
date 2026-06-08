using UnityEngine;
using UnityEngine.Audio;

public class EnemyBullet : MonoBehaviour
{
    float speed = 5f;
    public AudioSource audioSource;
    public AudioClip hitClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < -6f)
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
                playerHealth.TakeDamage(1f);
            }

            if (audioSource != null && hitClip != null)
            {
                audioSource.PlayOneShot(hitClip);
            }

            Destroy(gameObject, hitClip != null ? hitClip.length : 0f);
        }
    }
}
