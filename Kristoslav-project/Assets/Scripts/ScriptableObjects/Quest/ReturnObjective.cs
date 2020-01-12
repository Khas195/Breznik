
using UnityEngine;

[CreateAssetMenu(fileName = "Objective", menuName = "Quest/Objective/Collect", order = 0)]
public class ReturnObjective : Objective
{
    [SerializeField]
    CharacterData returnTo;
    public override void Activate()
    {
        base.Activate();
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }

    public override bool IsCompleted()
    {
        return base.IsCompleted();
    }

    public override void Reset()
    {
        base.Reset();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
