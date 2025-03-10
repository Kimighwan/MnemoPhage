using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    public D_Entity entityData;

    public int facingDirection {  get; private set; }
    public Rigidbody2D rigid {  get; private set; }
    public Animator anim {  get; private set; }
    public GameObject aliveGO { get; private set; }


    [SerializeField]
    private Transform wallCheck;                        // 벽 체크
    [SerializeField]
    private Transform ledgeCheck;                       // 낭떨어지 체크
    private Vector2 entityVelocity;


    public virtual void Start()
    {
        facingDirection = -1;

        aliveGO = transform.Find("Alive").gameObject;
        anim = aliveGO.GetComponent<Animator>();
        rigid = aliveGO.GetComponent<Rigidbody2D>();

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicalUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)     // 속도 설정
    {
        entityVelocity = new Vector2(facingDirection * velocity, rigid.linearVelocityY);
        rigid.linearVelocity = entityVelocity;
    }

    public virtual bool CheckWall()                     // 벽 체크
    {
        if (Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance, entityData.layerMask))
            Debug.Log("벽 감지");

        return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance, entityData.layerMask);
    }

    public virtual bool CheckLedge()                    // 낭떨어지 체크
    {
        if (!Physics2D.OverlapCircle(ledgeCheck.position, 0.14f, entityData.layerMask))
            Debug.Log($"땅 감지");

        return Physics2D.OverlapCircle(ledgeCheck.position, 0.14f, entityData.layerMask);


        //if (Physics2D.Raycast(ledgeCheck.position, aliveGO.transform.up * -1, entityData.ledgeCheckDistance, entityData.layerMask))
        //    Debug.Log($"땅 감지");

        //return Physics2D.Raycast(ledgeCheck.position, aliveGO.transform.up * -1, entityData.ledgeCheckDistance, entityData.layerMask);
    }

    public virtual void Flip()                          // 방향 전환
    {
        facingDirection *= -1;
        aliveGO.transform.Rotate(0f, 180f, 0f);
    }

    public virtual bool CheckPlayerInMinRange()
    {
        return true;
    }

    public virtual bool CheckPlayerInMaxRange()
    {
        return true;
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        //Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
        Gizmos.DrawWireSphere(ledgeCheck.position, 0.14f);
    }
}
