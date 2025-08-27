using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing3 : MonoBehaviour
{
    [SerializeField] private TilemapVisual tilemapVisual;
    private Tilemap tilemap;
    private Tilemap.TilemapObject.TilemapSprite tilemapSprite;

    private void Start()
    {
        tilemap = new Tilemap(17, 9, 10f, Vector3.zero);

        tilemap.SetTilemapVisual(tilemapVisual);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = GetMousePosition.GetMouseWorldPosition();
            tilemap.SetTilemapSprite(mouseWorldPosition, tilemapSprite);
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            tilemapSprite = Tilemap.TilemapObject.TilemapSprite.None;
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            tilemapSprite = Tilemap.TilemapObject.TilemapSprite.Ground;
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            tilemapSprite = Tilemap.TilemapObject.TilemapSprite.Path;
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            tilemapSprite = Tilemap.TilemapObject.TilemapSprite.Dirt;
        }
    }
}
