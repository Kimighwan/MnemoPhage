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
    public AnimationToStateMachine animationStateMachineAnimation { get; private set; }


    [SerializeField]
    private Transform wallCheck;                        // 벽 체크
    [SerializeField]
    private Transform ledgeCheck;                       // 낭떨어지 체크
    [SerializeField]
    private Transform playerCheck;                      // 플레이어 탐지
    private Vector2 entityVelocity;


    public virtual void Start()
    {
        facingDirection = -1;

        aliveGO = transform.Find("Alive").gameObject;
        anim = aliveGO.GetComponent<Animator>();
        rigid = aliveGO.GetComponent<Rigidbody2D>();
        animationStateMachineAnimation = aliveGO.GetComponent<AnimationToStateMachine>();

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


    #region Player Detected
    // 현재는 모든 몬스터가 어느 한 위치에서 일직선으로 탐지 한다 (2025_03_10)
    // 몬스터 종류가 많아지면서 탐지 방법이 달라진다면 변경하기

    public virtual bool CheckPlayerInMinRange()     // 플레이어가 몬스터의 최소 감지 범위에서 탐지되는지
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right * -1, entityData.playerDetectedMinRange, entityData.whatIsPlayer);
    }


    public virtual bool CheckPlayerInMaxRange()     // 플레이어가 몬스터의 최대 감지 범위에서 탐지되는지
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right * -1, entityData.playerDetectedMaxRange, entityData.whatIsPlayer); ;
    }

    #endregion

    public virtual bool CheckPlayerInMeleeAttackRange()     // 플레이어가 근접 공격 범위에 있는지
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.meleeAttackRangeDistance, entityData.whatIsPlayer);
    }



    public virtual void OnDrawGizmos()
    {
        // 벽 체크 씬창에 표시
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        //Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));

        // 땅 체크 씬창에 표시
        Gizmos.DrawWireSphere(ledgeCheck.position, 0.14f);

        // 플레이어 탐지 씬창에 표시
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.playerDetectedMinRange));    
    }
}
