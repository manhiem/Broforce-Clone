using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float knockbackForce;

    public bool isDead = false;

    private void Update()
    {
        if (health <= 0 && !isDead)
        {
            health = 0;
            isDead = true;
            anim.SetTrigger("Death");
        }
    }


    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float hp)
    {
        health -= hp;
    }

    public void TakeDamage(float damage)
    {
        anim.SetTrigger("Hit");
        SetHealth(damage);

        // Apply knockback force
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Get the character's facing direction
            float facingDirection = transform.localScale.x;

            // Calculate the knockback direction based on the facing direction
            Vector2 knockbackDirection = new Vector2(-facingDirection, 0f);

            // Apply the force
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
