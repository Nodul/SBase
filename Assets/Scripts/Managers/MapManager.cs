using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MapManager : MonoBehaviour {

    private static MapManager _instance;
    public static MapManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public Tile[,] Tiles;
    public int SizeX;
    public int SizeZ;
    public Vector2 PathfindingStartNode;
    public Vector2 PathfindingEndNode;

    private void Start()
    {
        ReassignTiles();
        //BFS.BFSPath(this.Tiles[(int)PathfindingStartNode.x,(int)PathfindingStartNode.y].GetComponent<Node>());
    }

    public void ReassignTiles()
    {
        var tiles = GameObject.FindGameObjectsWithTag("Tile");
        Tiles = new Tile[SizeX, SizeZ]; // I hope this won't cause any memory leaks

        foreach(var tile in tiles)
        {
            Tiles[(int)tile.transform.position.x, (int)tile.transform.position.z] = tile.GetComponent<Tile>();
            tile.GetComponent<Tile>().UpdateTile();
        }
    }

    public void UpdateTiles()
    {
        foreach(Tile tile in Tiles)
        {
            tile.UpdateTile();
        }
    }
}
