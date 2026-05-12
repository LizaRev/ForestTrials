using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform player;    
    public float damage = 5f;         
    public float attackRange = 3.5f; 
    public float attackRate = 1.0f;   
    public float speed = 2.0f;        
    private float nextAttackTime = 0f;

    // Переменная, чтобы запомнить твой масштаб из Инспектора
    private Vector3 startScale;

    void Start()
    {
        // Запоминаем масштаб (например, 10, 10, 1)
        startScale = transform.localScale;
    }

    void Update()
    {
        if (player == null) return; 

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            
            // ПОВОРОТ:
            // Если игрок справа (direction.x > 0), ставим обычный масштаб
            if (direction.x > 0) 
            {
                transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
            }
            // Если игрок слева, инвертируем по X (ставим минус)
            else 
            {
                transform.localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
            }
        }
        else if (Time.time >= nextAttackTime)
        {
            HitPlayer();
        }
    }

    void HitPlayer()
    {
        Health hp = player.GetComponent<Health>();
        if (hp != null)
        {
            hp.TakeDamage(damage); 
            nextAttackTime = Time.time + attackRate; 
            Debug.Log("УДАР ПО ГРАВЦЮ! Шкода: " + damage);
        }
    }
}