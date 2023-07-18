using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _attackCooldown;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private BoxCollider2D enemyCollider;
    [SerializeField]
    private float _range;
    [SerializeField]
    private float _colliderDistance;
    [SerializeField]
    private Transform attackPos;
    [SerializeField]
    private Health enemyHealth;

    private Animator enemyAnim;
    private float cooldownTimer = Mathf.Infinity;
    private EnemyPatrol enemyPatrol;
    private Health detectedPlayer;

    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
        enemyPatrol = GetComponent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(PlayerInSight())
        {
            if (cooldownTimer >= _attackCooldown)
            {
                cooldownTimer = 0;
                enemyAnim.SetTrigger("Attack");
            }
        }

        if(enemyPatrol!=null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject, .2f);
    }

    private bool PlayerInSight()
    {
        Debug.DrawRay(attackPos.position, Vector2.left * .8f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(attackPos.position, Vector2.left, .8f, playerLayer);

        if(hit.collider != null)
            detectedPlayer = hit.transform.gameObject.GetComponent<Health>();
        else
            detectedPlayer = null;


        return (hit.collider != null);
    }

    public void EnemyDamage()
    {
        detectedPlayer.TakeDamage(_damage);
    }
}
