using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Rigidbody2D playerRb;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private int attackRange;
    [SerializeField]
    private LayerMask enemyLayers;
    [SerializeField]
    private float damage;
    [SerializeField]
    private Health playerHealth;
    [SerializeField]
    private List<GameObject> spAtk = new List<GameObject>();

    private bool isJump = false;
    private bool groundEntered = false;
    public bool isLadder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        playerAnimator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        playerAnimator.SetFloat("Vertical", Mathf.Abs(vertical));

        MoveControl(horizontal);
        JumpControl(vertical);
        CheckHealth();

        if(Input.GetMouseButtonDown(0))
        {
            playerAnimator.SetTrigger("Attack");
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            playerAnimator.SetTrigger("SpAtk");
            GameObject go = spAtk[spAtk.Count - 1];
            go.SetActive(false);
            spAtk.RemoveAt(spAtk.Count - 1);
        }

        if (isLadder && Mathf.Abs(vertical) > 0)
        {
            playerRb.gravityScale = 0f;
            playerRb.velocity = new Vector2(playerRb.velocity.x, vertical * _moveSpeed);
        }
        else
        {
            playerRb.gravityScale = 2f;
        }
    }

    private void CheckHealth()
    {
        if (playerHealth.isDead)
        {
            Destroy(this.gameObject, .2f);
            SceneManager.LoadScene(2);
        }
    }

    private void JumpControl(float vertical)
    {
        if(!isJump && vertical > 0)
        {
            playerRb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            isJump = true;
        }

        if (playerRb.velocity.y >= -0.2f || groundEntered == true)
        {
            playerAnimator.SetBool("Fall", false);
            groundEntered = false;
        } 
        else if (playerRb.velocity.y < 0f)
        {
            playerAnimator.SetBool("Fall", true);
            isJump = false;
        }
    }

    private void MoveControl(float horizontal)
    {
        Vector3 playerScale = transform.localScale;
        if (horizontal < 0)
        {
            playerScale.x = -1 * Mathf.Abs(horizontal);
        }
        else if (horizontal > 0)
        {
            playerScale.x = Mathf.Abs(horizontal);
        }
        transform.localScale = playerScale;

        // Move Physics
        Vector3 curPos = transform.position;
        curPos.x += horizontal * _moveSpeed * Time.deltaTime;
        transform.position = curPos;
    }

    public void AttackEvent()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            SoundManager.Instance.Play(Sounds.PlayerAttack);
            enemy.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == null) return;
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision == null) return;
        if(collision.CompareTag("Ladder"))
        {
            isLadder = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            groundEntered = true;
        }
    }
}
