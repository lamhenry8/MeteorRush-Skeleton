using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public float waveAmount;
    public float waveSpeed;
    
    public GameObject enemyBulletPrefab;
    public Transform enemyFirePoint;
    float fireRate = 1.5f;

    public AudioSource audioSource;
    public AudioClip shootClip;
    public AudioClip explosionClip;

    float nextFireTime;
    float startY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = Random.Range(1.5f, 3f);
        waveAmount = Random.Range(0.2f, 1.5f);
        waveSpeed = Random.Range(1f, 3f);
        startY = transform.position.y;
        nextFireTime = Time.time + Random.Range(0.5f, fireRate);

        Debug.Log(audioSource);
        Debug.Log(audioSource.enabled);
        Debug.Log(audioSource.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        float Y = startY + Mathf.Sin(Time.time * waveSpeed) * waveAmount;
        transform.position = new Vector3(transform.position.x, Y, transform.position.z);

        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        if(transform.position.x > 3f || transform.position.x < -4f)
        {
            Destroy(gameObject, shootClip.length);
        }
    }

    void Shoot()
    {
        audioSource.PlayOneShot(shootClip);
        Instantiate(enemyBulletPrefab, enemyFirePoint.position, enemyFirePoint.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            AudioSource.PlayClipAtPoint(explosionClip, transform.position);
            Destroy(gameObject);
        }
    }

}
