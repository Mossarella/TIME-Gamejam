using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class SpawnObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Tile[] tileObjects;
    public Tilemap tileMapDunGeonTerrain;
    //public Tilemap tileMap;
    public LevelGeneration levelGen;
    //public Tile what;
    

    //private TilemapRenderer tileMapRender;
    //private TilemapCollider2D tilemapCollider2D;
    //private Vector3Int currentPos=new Vector3Int(100,100,100);

    void Start()
    {


        //tileMapDunGeonTerrain = GetComponent<LevelGeneration>().dungeonTerrainGenerated;

        tileMapDunGeonTerrain = Tilemap.FindObjectOfType<LevelGeneration>().dungeonTerrainGenerated;

        //Debug.Log(tileMapDunGeonTerrain.transform.position+"YEah");
        //tileMap =GetComponent<Tilemap>();


        //Vector3 currentPosFloat = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 currentPosFloat =transform.position;

        /*int intXPos = Mathf.RoundToInt(currentPosFloat.x);
        int intYPos = Mathf.RoundToInt(currentPosFloat.y);
        int intZPos = Mathf.RoundToInt(currentPosFloat.z);*/

        /*float x = 124.345f;
        int y = (int)x;*/


        //Vector3Int currentPos = new Vector3Int(intXPos,intYPos,intZPos);

        int rand = Random.Range(0, tileObjects.Length);

        //Instantiate(tileObjects[rand], transform.position, Quaternion.identity,transform.parent.transform);

        //tileMap.SetTile(tileMap.WorldToCell(currentPosFloat), tileObjects[Random]);
        tileMapDunGeonTerrain.SetTile(tileMapDunGeonTerrain.WorldToCell(currentPosFloat), tileObjects[rand]);

        //Vector3Int posCell = tileMapDunGeonTerrain.WorldToCell(currentPosFloat);

        //tileMapDunGeonTerrain.SetTile(tileMapDunGeonTerrain.WorldToCell(currentPosFloat), tileObjects[rand]);
        //Debug.Log(tileMapDunGeonTerrain.WorldToCell(currentPosFloat));
        //Debug.Log(posCell);



        //Tile instance = (Tile)Instantiate(tileObjects[rand], transform.position, Quaternion.identity);

        //instance.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
