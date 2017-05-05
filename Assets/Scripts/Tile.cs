using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public TileData TileData;
    public GameObject Wall;
    

    public void UpdateTile()
    {
        this.GetComponent<MeshRenderer>().material = this.TileData.Material;
        this.gameObject.name = string.Format("T-[{0},{1}]-{2}",transform.position.x,transform.position.z,this.TileData.Name);
    }
}
