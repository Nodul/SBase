using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class MinionMovementControl : MonoBehaviour {

    public Node StartNode;
    public Node EndNode;

    public float moveSpeed;
    public Vector3 currentDestination;
    public float destinationReachedThreshold = 0.05f;
    private bool DestinationSet;
    private static readonly Vector3 moveOffset = new Vector3(0,0.5f,0); //so minions won't go halfway through the ground

    private Queue<Node> movePath;

    private void Start()
    {
        PreparePath();
    }

    private void Update()
    {
        if (movePath.Count > 0)
        {
            if (!DestinationSet)
            {
                currentDestination = movePath.Dequeue().transform.position;
                DestinationSet = true;
            }


            if(Vector2.Distance(new Vector2(transform.position.x,transform.position.z),new Vector2(currentDestination.x,currentDestination.z)) > destinationReachedThreshold) // has not reached destination yet
            {
                Move();
            }
            else // destination reached
            {
                DestinationSet = false;
                Debug.Log("Destination reached");
            }

        }
    }

    private void Move()
    {
        Debug.Log("moving");
        this.transform.position = Vector3.MoveTowards(this.transform.position,currentDestination + moveOffset,moveSpeed);
    }

    private void PreparePath()
    {
        movePath = BFS.BFSPath(StartNode, EndNode);
       // Debug.Log("Prepared path length: "+movePath.Count);
        Debug.Log("First node: "+movePath.Peek().transform.position.ToString());
        
    }

}
