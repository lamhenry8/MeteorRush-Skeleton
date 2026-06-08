using UnityEngine;
using UnityEngine.Audio;

public class Meteor : MonoBehaviour
{
    float speed = 2f;

    public AudioSource audioSource;
    public AudioClip explosionClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player hit!");
            audioSource.PlayOneShot(explosionClip);
            Destroy(gameObject, explosionClip.length);
        }
    }
}
