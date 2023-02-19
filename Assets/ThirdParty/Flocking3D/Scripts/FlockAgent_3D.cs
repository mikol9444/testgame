using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FlockAgent_3D : MonoBehaviour
{
    BoxCollider agentCollider;
    public BoxCollider AgentCollider { get { return agentCollider; } }

    private void Start()
    {
        agentCollider = GetComponent<BoxCollider>();
    }

    public void Move(Vector3 velocity)
    {
        transform.forward = new Vector3(velocity.x, 0f, velocity.z);  //transform.forward for 3d 
        transform.position += new Vector3(velocity.x, 0f, velocity.z) * Time.deltaTime;
    }
}