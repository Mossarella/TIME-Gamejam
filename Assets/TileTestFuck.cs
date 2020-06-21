using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTestFuck : MonoBehaviour
{
    public Tilemap tilemap;

    public Tile wall;
    public Tile ground;

    void Start()
    {
        Debug.Log("fuck");
        Vector3 currentPosFloat = transform.position;
        //tilemap = GetComponent<Tilemap>();
        tilemap.SetTile(tilemap.WorldToCell(currentPosFloat), wall);
    }


    void Update()
    {
        
        //tilemap = GetComponent<Tilemap>();
    }
}
