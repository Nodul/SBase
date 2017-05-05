using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class Node : MonoBehaviour
    {
        public List<Node> neighbors = new List<Node>();
        public bool Blocked = false;

        private void Awake()
        {
            FindNeighbors(neighbors);
            if (this.GetComponent<Tile>().Wall != null)
            {
                Blocked = true;
               // this.GetComponentInChildren<TextMesh>().text = "";
            }
        }

        public void FindNeighbors(List<Node> _neighbors)
        {
            var hits = Physics.OverlapSphere(this.transform.position,1f,1 << 8); // 8 because Tiles layermask has number 8
            
            foreach(var hit in hits)
            {
                if(hit.gameObject != this.gameObject && hit.gameObject.tag == "Tile")
                {
                    neighbors.Add(hit.GetComponent<Node>());
                }
            }
        }

        public void MyTileTest(int distance)
        {
            /*
            //Tile tile = this.GetComponent<Tile>();
            //this.GetComponent<MeshRenderer>().material.color = Color.blue;
            if (!Blocked)
            {
                this.GetComponentInChildren<TextMesh>().text = string.Format("Tile[{0},{1}]\n{2}", this.transform.position.x, this.transform.position.z, distance);
            }
          
            */
        }
      
    }
}

