using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock_3D : MonoBehaviour
{
    public FlockAgent_3D agentPrefab;
    List<FlockAgent_3D> agents = new List<FlockAgent_3D>();
    public FlockBehavior_3D behavior;
    public Color defaultcolor;
    public Color setcolor = Color.red;
    [Range(0, 500)]
    public int startingCount = 250;
    public float AgentDensity = 0.08f;
    [Range(1f, 50f)]
    public float driveFactor = 10f;
    [Range(1f, 50f)]
    public float maxSpeed = 5f;
    [Range(0.01f, 50f)]
    public float neighborRadius = 1.5f;
    [Range(0.01f, 5f)]
    public float avoidanceRadiusMultiplier = 0.5f;
    public float maxcountColor = 10.0f;

    public float squareMaxSpeed;
    public float squareNeighborRadius;
    public float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    void Awake()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        defaultcolor = agentPrefab.GetComponentInChildren<Renderer>().sharedMaterial.color;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent_3D newAgent = Instantiate(
                agentPrefab,
                new Vector3(Random.onUnitSphere.x, 0, Random.onUnitSphere.z) * startingCount * AgentDensity,
                Quaternion.identity,
            //Quaternion.Euler(Vector3.one * Random.Range(0f, 360f)),
            transform);
            newAgent.name = "Agent " + i;
            agents.Add(newAgent);
        }

    }

    // Update is called once per frame
    void Update()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
        foreach (FlockAgent_3D agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            //FOR DEMO ONLY
            agent.GetComponentInChildren<Renderer>().material.color = Color.Lerp(defaultcolor, setcolor, (float)context.Count / maxcountColor);
            Vector3 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);


        }
    }

    List<Transform> GetNearbyObjects(FlockAgent_3D agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);
        foreach (Collider c in contextColliders)
        {
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;
    }
}
