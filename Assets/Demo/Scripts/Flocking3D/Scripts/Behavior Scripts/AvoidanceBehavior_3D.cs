using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock_3D/Behavior/Avoidance")]
public class AvoidanceBehavior_3D : FlockBehavior_3D
{
    public override Vector3 CalculateMove(FlockAgent_3D agent, List<Transform> context, Flock_3D flock)
    {
        // if no neighbors, return no adjustment
        if (context.Count == 0)
        {
            return Vector3.zero;
        }
        //add all points together and average
        Vector3 avoidanceMove = Vector3.zero;
        int nAvoid = 0;
        foreach (Transform item in context)
        {
            if (Vector3.SqrMagnitude(item.position - agent.transform.position) < flock.SquareAvoidanceRadius)
            {
                nAvoid++;
                avoidanceMove += (Vector3)(agent.transform.position - item.position);
            }
        }
        if (nAvoid > 0)
            avoidanceMove /= nAvoid;

        return avoidanceMove;
    }
}
