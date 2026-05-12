using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 7f;
    public float jumpForce = 12f;

    [Header("Ground Check")]
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.2f;
    public Transform groundCheckPoint;

    [Header("Shooting")]
    public GameObject bulletPrefab; 
    public Transform firePoint;     
    public float fireRate = 0.3f;   
    private float nextFireTime = 0f;

    private Rigidbody2D rb;
    private float horizontalInput;

    // --- ДОБАВЛЯЕМ ПЕРЕМЕННУЮ ДЛЯ МАСШТАБА ---
    private Vector3 startScale;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Запоминаем масштаб, который ты выставила в Инспекторе
        startScale = transform.localScale;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        FlipSprite();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Debug.Log("Постріл вгору!");
    }

    void FlipSprite()
    {
        // Вместо (1, 1, 1) теперь используем наш startScale
        if (horizontalInput > 0.1f) 
            transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
        else if (horizontalInput < -0.1f) 
            transform.localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
    }
}