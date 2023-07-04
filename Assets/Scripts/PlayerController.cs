using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private bool isJump = false;

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
    }

    private void JumpControl(float vertical)
    {
        if(!isJump && vertical > 0)
        {
            playerRb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            isJump = true;
        }

        if (playerRb.velocity.y >= -0.2f)
        {
            playerAnimator.SetBool("Fall", false);
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
}
