using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class MinionMovementControl : MonoBehaviour {

    private Node StartNode;
    private Node EndNode;
    private Minion Minion;

    public float moveSpeed;
    private Vector3 currentDestination;
    private float destinationReachedThreshold = 0.05f;
    private bool DestinationSet;
    private static readonly Vector3 moveOffset = new Vector3(0,0.5f,0); //so minions won't go halfway through the ground

    private Queue<Node> movePath;

    private void Awake()
    {
        if (Minion == null) Minion = GetComponent<Minion>();
    }

    private void Start()
    {
        GetClosestNode();
    }

    private void Update()
    {
        if(movePath != null) // Do I have an actual path to follow?
        {
            if (Minion.MinionState == MinionState.Moving && movePath.Count > 0)
            {
                if (!DestinationSet)
                {
                    // Aquiring next destination from calculated path
                    currentDestination = movePath.Dequeue().transform.position;
                    DestinationSet = true;
                }


                if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(currentDestination.x, currentDestination.z)) > destinationReachedThreshold) // has not reached destination yet
                {
                    MoveStep();
                }
                else
                {
                    DestinationSet = false;
                    Debug.Log("Current destination reached");

                }

            }
            else if (Minion.MinionState == MinionState.Moving && movePath.Count == 0)
            {
                Minion.MinionState = MinionState.Idle;
                Debug.Log("Final destination reached");
            }
        }
   
    }

    private void MoveStep()
    {
        Debug.Log("Moving");
        this.transform.position = Vector3.MoveTowards(this.transform.position,currentDestination + moveOffset,moveSpeed);
    }
    /// <summary>
    /// Access point for Minion to give move orders to it's gameobject
    /// </summary>
    /// <param name="startNode"></param>
    /// <param name="endNode"></param>
    public void MoveOrder(Node endNode)
    {
        GetClosestNode();
        this.EndNode = endNode;
        PreparePath();
    }

    private void PreparePath()
    {

        if(StartNode != EndNode) 
        {
            movePath = BFS.BFSPath(StartNode, EndNode);
            if (movePath.Count == 0)
            {
                Debug.Log("Prepared an empty movePath, because EndNode is inaccesible");
            }
            else
            {
                // Debug.Log("Prepared path length: "+movePath.Count);
                Debug.Log("First node: " + movePath.Peek().transform.position.ToString());
            }
        }
        else // Already arrived XD
        {
            Debug.Log("Tried to move to same node, cancelling");
        }

        
    }

    /// <summary>
    /// Finds closest Node to the entity and assigns it to StartNode. 
    /// </summary>
    /// <returns></returns>
    public void GetClosestNode()
    {
        Node closestNode = null;

        var nodes = Physics.OverlapSphere(this.transform.position, 0.55f, 1 << 8);
        closestNode = nodes[0].GetComponent<Node>();

        StartNode = closestNode;
    }

}
