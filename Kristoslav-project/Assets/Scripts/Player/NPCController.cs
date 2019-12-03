using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    [SerializeField]
    [BoxGroup("Requirements")]
    [Required]
    Character aiCharacter = null;



    [SerializeField]
    [BoxGroup("Requirements")]
    [Required]
    ScriptableState currentState = null;



    [SerializeField]
    [BoxGroup("Requirements")]
    ScriptableState remainInState;

    [SerializeField]
    [BoxGroup("Settings")]
    bool isAIActive = false;

    [SerializeField]
    [BoxGroup("Settings")]
    [ReadOnly]
    public Transform chaseTarget = null;


    [SerializeField]
    [ReadOnly]
    Vector3 currentDestination = Vector3.zero;
    [SerializeField]
    LayerMask enemyMasks;

    NavMeshPath currentPath = null;
    int currentPoint = 0;

    //Test
    Transform rootPosition;
    float patrolRange;
    void Awake()
    {
        currentPath = new NavMeshPath();
        currentDestination = aiCharacter.GetHost().transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isAIActive == false)
        {
            return;
        }
        if (currentState)
        {
            currentState.UpdateState(this);
        }
        ProcessMovement();
    }

    public void SetAiActive(bool active)
    {
        this.isAIActive = active;
    }

    public void SetPatrolRange(int size)
    {
        this.patrolRange = size;
    }

    public void SetHome(Transform transform)
    {
        this.rootPosition = transform;
    }

    private void ProcessMovement()
    {
        if (HasReachedCurrentDestination() == false)
        {
            if (IsPathStillValid() == false)
            {
                this.SetDestination(currentDestination);
                aiCharacter.RequestMove(0, 0);
                return;
            }
            var currentPos = currentPath.corners[currentPoint];

            if (HasReachPoint(currentPos) == false)
            {
                ConvertDirectionToCharacterMoveInput(currentPos);
            }
            else
            {
                AdvanceToNextPointInPath();
                aiCharacter.RequestMove(0, 0);
            }
        }
        else
        {
            aiCharacter.RequestMove(0, 0);
        }
    }
    public void SetMovement(IMovement.MovementType moveType)
    {
        aiCharacter.RequestMovementType(moveType);
    }
    private bool IsPathStillValid()
    {
        Transform charTransform = aiCharacter.GetHost().transform;
        NavMeshHit hit;
        if (currentPoint >= currentPath.corners.Length)
        {
            return false;
        }
        if (NavMesh.SamplePosition(charTransform.position, out hit, aiCharacter.GetStats().stoppingDistance, 1))
        {
            if (NavMesh.CalculatePath(hit.position, currentPath.corners[currentPoint], 1, new NavMeshPath()) == false)
            {
                return false;
            }
        }
        return true;
    }

    private void AdvanceToNextPointInPath()
    {
        currentPoint++;
    }
    public bool IsInAttackLine(Transform target)
    {
        var dirToTarget = (target.transform.position - aiCharacter.GetHost().transform.position).normalized;
        var angleFromFrontToTarget = Vector3.Angle(aiCharacter.GetHost().transform.forward, dirToTarget);
        return angleFromFrontToTarget <= 20f;
    }
    private void ConvertDirectionToCharacterMoveInput(Vector3 currentPoint)
    {
        var hostTransform = aiCharacter.GetHost().transform;
        var direction = (currentPoint - hostTransform.position).normalized;
        float forward = direction.z;
        float side = direction.x;

        aiCharacter.RotateToward(direction, rotateY: false);
        forward = Mathf.Abs(forward) > Mathf.Abs(side) ? Mathf.Abs(forward) : Mathf.Abs(side);
        aiCharacter.RequestMove(forward, 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(aiCharacter.GetHost().transform.position, aiCharacter.GetStats().stoppingDistance);

        if (isAIActive && currentState)
        {
            Gizmos.color = currentState.GetGizmosColor();
            Gizmos.DrawWireSphere(aiCharacter.GetHost().transform.position, aiCharacter.GetStats().aggroRange);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(aiCharacter.GetHost().transform.position, aiCharacter.GetStats().attackRange);

        if (currentPath != null)
        {
            for (int i = 0; i < currentPath.corners.Length - 1; i++)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(currentPath.corners[i], 2f);
                Gizmos.color = Color.green;
                Gizmos.DrawLine(currentPath.corners[i], currentPath.corners[i + 1]);
            }
        }
    }
    public bool HasReachPoint(Vector3 point)
    {
        var distance = Vector3.Distance(point, aiCharacter.GetHost().transform.position);
        if (distance <= 0.1f)
        {
            return true;
        }
        return false;
    }
    public bool HasReachedCurrentDestination()
    {

        var distance = Vector3.Distance(currentDestination, aiCharacter.GetHost().transform.position);
        if (distance <= aiCharacter.GetStats().stoppingDistance)
        {
            return true;
        }
        return false;
    }
    public NavMeshPath GetCurrentPath()
    {
        return currentPath;
    }

    public bool SetDestination(Vector3 newDestination)
    {
        currentDestination = newDestination;
        return CalculatePath(currentDestination);
    }

    private bool CalculatePath(Vector3 newDestination)
    {
        currentPath.ClearCorners();
        Transform charTransform = aiCharacter.GetHost().transform;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(charTransform.position, out hit, aiCharacter.GetStats().stoppingDistance, NavMesh.AllAreas))
        {
            if (hit.position.x != Mathf.Infinity && newDestination.x != Mathf.Infinity)
            {
                NavMesh.CalculatePath(hit.position, newDestination, 1, currentPath);
                currentPoint = 1;
                return true;
            }
        }
        return false;
    }

    public Vector3 GetRandomPointInArea()
    {
        var randomDirection = (UnityEngine.Random.insideUnitSphere * patrolRange) + rootPosition.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, patrolRange, 1);
        return hit.position;
    }
    public bool LookForHostile()
    {
        Transform characterTransform = aiCharacter.GetHost().transform;
        CharacterData stats = aiCharacter.GetStats();
        Collider[] cols = Physics.OverlapSphere(characterTransform.position, stats.aggroRange, enemyMasks);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].gameObject.CompareTag("Player"))
            {
                this.chaseTarget = cols[i].gameObject.transform;
                return true;
            }
        }
        return false;
    }
    public void RequestTransition(ScriptableState nextState)
    {
        if (nextState != remainInState)
        {
            currentState = nextState;
        }
    }
    public Transform GetChaseTarget()
    {
        return chaseTarget;
    }
    public bool DoesChaseTargetExist()
    {
        if (chaseTarget != null && chaseTarget.gameObject.activeInHierarchy == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsInAttackRange(Vector3 position)
    {
        if (Vector3.Distance(aiCharacter.GetHost().transform.position, position) <= aiCharacter.GetStats().attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Attack()
    {
        aiCharacter.Attack();
    }
    public void RotateToward(Transform target)
    {
        var direction = target.position - aiCharacter.GetHost().transform.position;
        aiCharacter.RotateToward(direction.normalized, false);
    }
}