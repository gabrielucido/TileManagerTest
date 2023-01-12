using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardController : MonoBehaviour
{
    private Tilemap walkableTilemap;

    public int width = 10;
    public int height = 10;

    public Sprite wall;
    public Sprite ground;

    void Start()
    {
        this.walkableTilemap = transform.Find("_Walkable").gameObject.GetComponent<Tilemap>();
        //this.walkableTilemap.ClearAllTiles();

        var tile = TileBase.CreateInstance<TileBase>();

        for (int i = 0; i < width; i++)
        {
            this.walkableTilemap.SetTile(new Vector3Int(i, 0, 0), tile);
            var currentTile = this.walkableTilemap.GetTile<Tile>(new Vector3Int(i, 0, 0));
            currentTile.sprite = this.wall;
            this.walkableTilemap.SetTile(new Vector3Int(i, 0, 0), (TileBase)currentTile);
        }

        Tile tile00 = (Tile)this.walkableTilemap.GetTile(new Vector3Int(0, 0, 0));
        Tile neighborTile = (Tile)this.walkableTilemap.GetTile(new Vector3Int(1, 0, 0));
        Debug.Log(tile00);
        Debug.Log(neighborTile);
    }
}
