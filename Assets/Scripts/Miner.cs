using UnityEngine;

public class Miner : MonoBehaviour
{
    [SerializeField] protected float damage = 10;
    [SerializeField] protected float miningSpeed = 1;

    protected float startTimeBtwAttacks;
    protected float timeBtwAttacks;

    protected virtual void Awake()
    {
        startTimeBtwAttacks = 1 / miningSpeed;
    }

    protected virtual void FixedUpdate()
    {
        if (timeBtwAttacks > 0)
            timeBtwAttacks -= Time.fixedDeltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Asteroid asteroid))
        {
            if (timeBtwAttacks <= 0)
                Attack(asteroid);
        }
    }

    protected virtual void Attack(Damageable target)
    {
        target.TakeDamage(damage);

        timeBtwAttacks = startTimeBtwAttacks;

        Debug.Log(gameObject.name + " attacks!");
    }
}
