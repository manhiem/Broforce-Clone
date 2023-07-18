using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    private float _patrolSpeed;
    [SerializeField]
    private Vector3 leftEdge;
    [SerializeField]
    private Vector3 rightEdge;
    [SerializeField]
    private Animator enemyAnimator;
    [SerializeField]
    private float idleDuration;
    private float idleTimer;

    private Vector3 _initScale;
    private bool movingLeft;

    private void Awake()
    {
        _initScale = transform.localScale;
    }

    private void Update()
    {
        if(movingLeft)
        {
            if (transform.position.x >= leftEdge.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (transform.position.x <= rightEdge.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
        enemyAnimator.SetBool("Moving", false);
        idleTimer += Time.deltaTime;
        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        enemyAnimator.SetBool("Moving", true);
        // Make enemy face the direction
        transform.localScale = new Vector3(_initScale.x * _direction, _initScale.y, _initScale.z);

        // Make enemy move in that direction
        transform.position = new Vector3(transform.position.x + Time.deltaTime * _direction * _patrolSpeed,
            transform.position.y, transform.position.z);
    }

    private void OnDisable()
    {
        enemyAnimator.SetBool("Moving", false);
    }

}
