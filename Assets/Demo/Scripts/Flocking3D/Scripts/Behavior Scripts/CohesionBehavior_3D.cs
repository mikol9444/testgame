using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock_3D/Behavior/Cohesion")]
public class CohesionBehavior_3D : FlockBehavior_3D
{
    public override Vector3 CalculateMove(FlockAgent_3D agent, List<Transform> context, Flock_3D flock)
    {
        // if no neighbors, return no adjustment
        if (context.Count == 0)
        {
            return Vector3.zero;
        }
        //add all points together and average
        Vector3 cohesionMove = Vector3.zero;
        foreach (Transform item in context)
        {
            cohesionMove += (Vector3)item.position;
        }
        cohesionMove /= context.Count;

        //CreateAssetMenuAttribute offset from agent position
        cohesionMove -= (Vector3)agent.transform.position;
        return cohesionMove;
    }

}
