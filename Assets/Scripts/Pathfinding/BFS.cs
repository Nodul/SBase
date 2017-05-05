using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pathfinding
{
    public static class BFS
    {
        /// <summary>
        /// Gives back dictionary of nodes, basically all pathways to startNode
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="endNode"></param>
        /// <returns></returns>
        public static Dictionary<Node,Node> BFSAlgo(Node startNode, Node endNode, bool earlyExit = true)
        {
            int steps = 0;
            Queue<Node> frontier = new Queue<Node>();
            frontier.Enqueue(startNode);

            Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node> { { startNode, null } };

            while (frontier.Count > 0)
            {
                steps++;

                Node current = frontier.Dequeue();

                if (earlyExit && current == endNode) break; // early exit, if we find what we want

                // Handle neighbors (if any)
                foreach (Node node in current.neighbors)
                {
                    if (!cameFrom.ContainsKey(node) && !node.Blocked)
                    {
                        frontier.Enqueue(node);
                        cameFrom.Add(node,current);
                    }                                   
                }
                //Do something
                //current.MyTileTest(distance[current]);

            }// end While

            return cameFrom;
        }

        /// <summary>
        /// Find path to endNode from startNode. 
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="endNode"></param>
        /// <returns></returns>
        public static Queue<Node> BFSPath(Node startNode, Node endNode)
        {
            
            if (!endNode.Blocked) // So you won't even try to access inaccesible tiles
            {
                Dictionary<Node, Node> cameFrom = BFSAlgo(startNode, endNode);
                // Reconstructing the path
                Node currentNode = endNode;
                Queue<Node> path = new Queue<Node>();
                path.Enqueue(currentNode);

                while (currentNode != startNode)
                {
                    currentNode = cameFrom[currentNode];
                    path.Enqueue(currentNode);
                }
                path = new Queue<Node>(path.Reverse());
                path.Enqueue(endNode);

                return path;
            }
            else
            {
                return new Queue<Node>(); //new empty Queue, since you cannot reach a blocked end node
            }

        }

    }
}
