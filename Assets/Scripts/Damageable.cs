using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] protected float startHealth;

    protected float health;

    protected virtual void Start()
    {
        health = startHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
