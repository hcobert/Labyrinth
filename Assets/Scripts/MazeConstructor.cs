using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MazeConstructor : MonoBehaviour
{
    public Tilemap tMap;
    public TileBase tile;
    public Vector3Int vector;
    // Start is called before the first frame update
    void Start()
    {
        vector.x = 0;
        vector.y = 0;
        vector.z = 0;
        tMap.SetTile(vector,tile);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
