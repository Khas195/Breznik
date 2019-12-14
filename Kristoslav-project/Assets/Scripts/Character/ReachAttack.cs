
using NaughtyAttributes;
using UnityEngine;

public class ReachAttack : MonoBehaviour
{
    [SerializeField]
    [Required]
    Character attacker = null;
    [SerializeField]
    [ReadOnly]
    GameObject attackerHost;

    [SerializeField]
    [ReadOnly]
    float attackRange = 0;
    [SerializeField]
    [ReadOnly]
    float reachRange = 0;
    [SerializeField]
    [ReadOnly]
    LayerMask enemiesMask;
    [SerializeField]
    float followPercentage = 0.1f;
    bool shouldMove = false;
    Vector3 desiredPosition = Vector3.zero;
    void Awake()
    {
        attackerHost = attacker.GetHost();
        attackRange = attacker.GetCharacterDataPack().attackRange;
        reachRange = attacker.GetCharacterDataPack().reachRange;
        enemiesMask = attacker.GetCharacterDataPack().enemiesMask;

    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (shouldMove)
        {
            if (Vector3.Distance(desiredPosition, attackerHost.transform.position) > 1f)
            {
                attackerHost.transform.position = Vector3.Lerp(attackerHost.transform.position, desiredPosition, followPercentage);
            }
            else
            {
                shouldMove = false;
            }
        }
    }
    void OnDrawGizmos()
    {
        if (attacker != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(attacker.GetHost().transform.position, attacker.GetCharacterDataPack().reachRange);
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(attacker.GetHost().transform.position, attacker.GetCharacterDataPack().attackRange);
        }
    }

    public void TryReachTargetInDirection(Vector3 desiredDirection)
    {
        if (reachRange == 0) return;
        Debug.Log("Try TO Reach");
        var cols = Physics.OverlapSphere(attackerHost.transform.position, reachRange, enemiesMask);
        if (cols.Length > 0)
        {
            Debug.Log("Enemies in Reach Range");
            Collider closest = null;
            float smallestAngle = 0;
            FindClostTargetToFacingDIrection(desiredDirection, cols, out closest, out smallestAngle);

            if (smallestAngle > 90) return;
            float distanceFromTarget = Vector3.Distance(attackerHost.transform.position, closest.transform.position);
            if (distanceFromTarget <= attackRange) return;

            Vector3 predictDir = (closest.transform.position - attackerHost.transform.position).normalized;
            predictDir.y = 0;
            desiredPosition = attackerHost.gameObject.transform.position + predictDir * (distanceFromTarget - attackRange);
            shouldMove = true;
        }
    }

    private void FindClostTargetToFacingDIrection(Vector3 desiredDirection, Collider[] cols, out Collider closest, out float smallestAngle)
    {
        closest = cols[0];
        smallestAngle = Vector3.Angle((closest.transform.position - attackerHost.transform.position).normalized, desiredDirection);
        foreach (var col in cols)
        {
            float angle = Vector3.Angle((col.transform.position - attackerHost.transform.position).normalized, desiredDirection);
            if (angle < smallestAngle)
            {
                smallestAngle = angle;
                closest = col;
            }
        }
    }
}