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
    bool isAIActive = true;



    [SerializeField]
    [BoxGroup("Settings")]
    [ReadOnly]
    public Transform chaseTarget = null;



    [SerializeField]
    [ReadOnly]
    Vector3 currentDestination = Vector3.zero;

    NavMeshPath currentPath = null;
    int currentPoint = 0;

    //Test
    [SerializeField]
    Transform rootPosition;
    [SerializeField]
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
    private void ProcessMovement()
    {
        if (HasReachedCurrentDestination() == false)
        {
            if (IsPathStillValid() == false)
            {
                Debug.Log("Path invalid, recalculating path ");
                this.SetDestination(currentDestination);
                aiCharacter.RequestMove(0, 0);
                return;
            }

            Debug.Log("Path Still Valid ");
            var currentPos = currentPath.corners[currentPoint];

            if (HasReachPoint(currentPos) == false)
            {

                Debug.Log("Proceed To point");
                ConvertDirectionToCharacterMoveInput(currentPos);
            }
            else
            {
                Debug.Log("Advance to next point");
                AdvanceToNextPointInPath();
                aiCharacter.RequestMove(0, 0);
            }
        }
        else
        {
            aiCharacter.RequestMove(0, 0);
        }
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
                Debug.Log("Failed To calculate Path");
                return false;
            }
        }
        return true;
    }

    private void AdvanceToNextPointInPath()
    {
        currentPoint++;
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

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(rootPosition.position, patrolRange);
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

    public void SetDestination(Vector3 newDestination)
    {
        currentDestination = newDestination;
        CalculatePath(currentDestination);
    }

    private void CalculatePath(Vector3 newDestination)
    {
        currentPath.ClearCorners();
        Transform charTransform = aiCharacter.GetHost().transform;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(charTransform.position, out hit, aiCharacter.GetStats().stoppingDistance, 1))
        {
            NavMesh.CalculatePath(hit.position, newDestination, 1, currentPath);
            currentPoint = 1;
        }
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
        Collider[] cols = Physics.OverlapSphere(characterTransform.position, stats.aggroRange, LayerMask.GetMask("HitBox"));
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
    public void Attack(Transform target)
    {
        var direction = target.position - aiCharacter.GetHost().transform.position;
        aiCharacter.RotateToward(direction.normalized, false);
        aiCharacter.Attack();
    }
}