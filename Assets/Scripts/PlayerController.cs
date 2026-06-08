using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 5f;
    Vector2 moveInput;

    float minX = -2.5f;
    float maxX = 2.5f;

    float minY = -4.75f;
    float maxY = 4.75f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    float fireRate = 0.25f;
    float nextFireTime = 0f;

    public AudioSource audioSource;
    public AudioClip shootClip;
    public AudioClip explosionClip;

    private GameManager gameManager;
    private Health playerHealth;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnAttack()
    {
        if (gameManager != null && gameManager.IsGameOver)
        {
            return;
        }

        audioSource.PlayOneShot(shootClip);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        nextFireTime = Time.time + fireRate;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0);
        transform.position += movement * moveSpeed * Time.deltaTime;
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);    

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet") || other.CompareTag("Meteor"))
        {
            if (audioSource != null && explosionClip != null)
            {
                audioSource.PlayOneShot(explosionClip);
            }

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1f);
            }

            if (other.CompareTag("EnemyBullet"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
