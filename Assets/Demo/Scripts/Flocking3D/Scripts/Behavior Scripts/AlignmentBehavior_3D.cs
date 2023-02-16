using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock_3D/Behavior/Alignment")]
public class AlignmentBehavior_3D : FlockBehavior_3D
{
    public override Vector3 CalculateMove(FlockAgent_3D agent, List<Transform> context, Flock_3D flock)
    {
        // if no neighbors, maintain current alignment
        if (context.Count == 0)
        {
            return agent.transform.forward;
        }
        //add all points together and average
        Vector3 alignmentMove = Vector3.zero;
        foreach (Transform item in context)
        {
            alignmentMove += (Vector3)item.transform.forward;
        }
        alignmentMove /= context.Count;
        return alignmentMove;
    }
}
