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
    ScriptableState remainInState = null;

    [SerializeField]
    [BoxGroup("Settings")]
    bool isAIActive = false;

    [SerializeField]
    [BoxGroup("Settings")]
    [ReadOnly]
    public Transform chaseTarget = null;
    [SerializeField]
    GameObject patrolPathHolder = null;
    [SerializeField]
    [ReadOnly]
    List<Vector3> patrolPath = new List<Vector3>();

    [SerializeField]
    [ReadOnly]
    Vector3 currentDestination = Vector3.zero;
    [SerializeField]
    LayerMask enemyMasks;

    NavMeshPath currentPath = null;
    int currentPoint = 0;
    int curPointInPath = -1;

    ScriptableState beginState = null;



    void Awake()
    {
        currentPath = new NavMeshPath();
        currentDestination = aiCharacter.GetHost().transform.position;
        beginState = currentState;
    }
    // Start is called before the first frame update
    void Start()
    {
        patrolPath.Clear();
        patrolPath.Add(aiCharacter.GetHost().transform.position);
        if (patrolPathHolder)
        {
            var transforms = patrolPathHolder.GetComponentsInChildren<Transform>();
            foreach (var trans in transforms)
            {
                if (trans == patrolPathHolder.transform)
                {
                    continue;
                }
                patrolPath.Add(trans.position);
            }
        }

        this.SetAiActive(true);
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
    public bool IsOutOfRange(Vector3 position)
    {
        var bounds = new Bounds(patrolPath[0], Vector3.zero);
        foreach (var item in patrolPath)
        {
            bounds.Encapsulate(item);
        }

        if (Vector3.Distance(bounds.center, position) > aiCharacter.GetCharacterDataPack().chaseRange)
        {
            return true;
        }
        return false;
    }
    private int GetClosestPatrolIndex(Vector3 position, int closestPos)
    {
        var closestDistance = Vector3.Distance(patrolPath[closestPos], position);
        for (int i = 0; i < patrolPath.Count; ++i)
        {
            var distance = Vector3.Distance(patrolPath[i], position);
            if (distance < closestDistance)
            {
                closestPos = i;
                closestDistance = distance;
            }
        }

        return closestPos;
    }
    bool reversePath = false;
    public Vector3 GetNextPointInPath()
    {
        if (reversePath == false)
        {
            curPointInPath += 1;
            if (curPointInPath >= patrolPath.Count)
            {
                reversePath = true;
            }
        }
        else
        {
            curPointInPath -= 1;
            if (curPointInPath <= 0)
            {
                reversePath = false;
            }
        }
        curPointInPath = Mathf.Clamp(curPointInPath, 0, patrolPath.Count - 1);
        return patrolPath[curPointInPath];
    }

    public void SetAiActive(bool active)
    {
        this.isAIActive = active;
        if (MonsterManager.GetInstance())
        {
            if (isAIActive == false)
            {
                MonsterManager.GetInstance().OnAiDeactivated(this);
            }
            else
            {
                MonsterManager.GetInstance().OnAiActivated(this);
            }
        }

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

    public GameObject GetHost()
    {
        return aiCharacter.GetHost();
    }

    public void SetMovement(IMovement.MovementType moveType)
    {
        aiCharacter.RequestMovementType(moveType);
    }

    public void Revive()
    {
        currentState = beginState;
        aiCharacter.Revive();
    }

    private bool IsPathStillValid()
    {
        Transform charTransform = aiCharacter.GetHost().transform;
        NavMeshHit hit;
        if (currentPoint >= currentPath.corners.Length)
        {
            return false;
        }
        if (NavMesh.SamplePosition(charTransform.position, out hit, aiCharacter.GetCharacterDataPack().stoppingDistance, 1))
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
        Gizmos.DrawWireSphere(aiCharacter.GetHost().transform.position, aiCharacter.GetCharacterDataPack().stoppingDistance);

        if (isAIActive && currentState)
        {
            Gizmos.color = currentState.GetGizmosColor();
            Gizmos.DrawWireSphere(aiCharacter.GetHost().transform.position, aiCharacter.GetCharacterDataPack().aggroRange);

        }

        Gizmos.color = Color.yellow;
        patrolPath.Clear();
        if (patrolPathHolder != null)
        {
            var transforms = patrolPathHolder.GetComponentsInChildren<Transform>();
            foreach (var trans in transforms)
            {
                if (trans == patrolPathHolder.transform)
                {
                    continue;
                }
                patrolPath.Add(trans.position);
            }
        }
        if (patrolPath.Count > 0)
        {
            var bounds = new Bounds(patrolPath[0], Vector3.zero);
            foreach (var item in patrolPath)
            {
                bounds.Encapsulate(item);
            }
            Gizmos.DrawWireSphere(bounds.center, 1f);
            Gizmos.DrawWireSphere(bounds.center, aiCharacter.GetCharacterDataPack().chaseRange);
            for (int i = 0; i < patrolPath.Count - 1; ++i)
            {
                Gizmos.DrawLine(patrolPath[i], patrolPath[i + 1]);
            }
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(aiCharacter.GetHost().transform.position, aiCharacter.GetCharacterDataPack().attackRange);

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
        if (distance <= aiCharacter.GetCharacterDataPack().stoppingDistance)
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
        if (CalculatePath(newDestination))
        {
            currentDestination = newDestination;
            return true;
        }
        return false;
    }

    private bool CalculatePath(Vector3 newDestination)
    {
        currentPath.ClearCorners();
        Transform charTransform = aiCharacter.GetHost().transform;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(charTransform.position, out hit, aiCharacter.GetCharacterDataPack().stoppingDistance, NavMesh.AllAreas))
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

    public bool LookForHostile()
    {
        Transform characterTransform = aiCharacter.GetHost().transform;
        CharacterData stats = aiCharacter.GetCharacterDataPack();
        Collider[] cols = Physics.OverlapSphere(characterTransform.position, stats.aggroRange, enemyMasks);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].gameObject.CompareTag("Player"))
            {
                if (IsOutOfRange(cols[i].gameObject.transform.position) == false)
                {
                    this.chaseTarget = cols[i].gameObject.transform;
                    return true;
                }
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
        if (Vector3.Distance(aiCharacter.GetHost().transform.position, position) <= aiCharacter.GetCharacterDataPack().attackRange)
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