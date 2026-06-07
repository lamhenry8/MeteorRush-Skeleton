using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 35f;
    Vector2 moveInput;

    float minX = -2.5f;
    float maxX = 2.5f;

    float minY = -4.75f;
    float maxY = 4.75f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    float fireRate = 0.25f;
    float nextFireTime = 0f;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnAttack()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        nextFireTime = Time.time + fireRate;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0) * moveSpeed * Time.deltaTime;
        transform.position += movement * moveSpeed * Time.deltaTime;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);    
        transform.position = pos;
    }
}
