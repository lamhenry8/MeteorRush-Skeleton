using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 20f;

     
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
}
