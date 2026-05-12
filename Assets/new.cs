using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 7f;
    public float jumpForce = 12f;

    [Header("Ground Check")]
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    public Transform groundCheckPoint;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;

    private Rigidbody2D rb;
    private float horizontalInput;
    private float nextFireTime = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Рух вліво/вправо
        horizontalInput = Input.GetAxis("Horizontal");

        // Стрибки
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Стрілянина
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        FlipSprite();
    }

    void FixedUpdate()
    {
        // Рух гравця по горизонталі
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    void FlipSprite()
    {
        if (horizontalInput > 0.1f) transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalInput < -0.1f) transform.localScale = new Vector3(-1, 1, 1);
    }
}