using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public TileData TileData;
    public GameObject Wall;

    private void Awake()
    {
        if (CheckForWall())
        {
            this.GetComponent<Pathfinding.Node>().Blocked = true;
        }
        else
        {
            this.GetComponent<Pathfinding.Node>().Blocked = false;
        }
    }

    public void UpdateTile()
    {
        this.GetComponent<MeshRenderer>().material = this.TileData.Material;
        this.gameObject.name = string.Format("T-[{0},{1}]-{2}", transform.position.x, transform.position.z, this.TileData.Name);
    }

    public bool CheckForWall()
    {
        var objects = Physics.OverlapSphere(this.transform.position, 0.2f);

        foreach (var obj in objects)
        {
            if(obj.gameObject.tag == "Wall")
            {
                this.Wall = obj.gameObject;
                return true;
            }
        }

        Wall = null;
        return false;
    }
}
