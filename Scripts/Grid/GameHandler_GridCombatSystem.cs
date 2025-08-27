using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static GridCombatSystem;

public class GameHandler_GridCombatSystem : MonoBehaviour
{
    public static GameHandler_GridCombatSystem Instance { get; private set; }

    [SerializeField] private TilemapVisual tilemapVisual;
    [SerializeField] private TilemapVisual walkableTilemapVisual;
    [SerializeField] private Transform cinemachineFollowTransform;

    private Grid<GridObject> grid;
    private Tilemap tilemap;
    private Tilemap walkableTilemap;
    public Pathfinding pathfinding;

    private void Awake()
    {
        Instance = this;

        int width = 20;
        int height = 22;
        float cellSize = 10f;
        Vector3 origin = Vector3.zero;

        grid = new Grid<GridObject>(width, height, cellSize, origin, (Grid<GridObject> g, int x, int y) => new GridObject(g, x, y));

        pathfinding = new Pathfinding(width, height);

        tilemap = new Tilemap(width, height, cellSize, origin);
        walkableTilemap = new Tilemap(width, height, cellSize, new Vector3(0,0, 10));
    }

    private void Start()
    {
        tilemap.SetTilemapVisual(tilemapVisual);
        walkableTilemap.SetTilemapVisual(walkableTilemapVisual);
    }

    private void Update()
    {
        HandleCameraMovement();
    }

    public void Delay(Action test)
    {
        StartCoroutine(DelayBeforeSuccess(test));
    }

    IEnumerator DelayBeforeSuccess(Action test)
    {
        yield return new WaitForSeconds(1);
        test();
    }

    private void HandleCameraMovement()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 deltaPosition = touch.deltaPosition;
            Vector3 moveDir = new Vector3(deltaPosition.x, deltaPosition.y, 0);
            
            moveDir.Normalize();

            float moveSpeed = 80f;
            cinemachineFollowTransform.position += moveDir * moveSpeed * Time.deltaTime;
        }
    }

    public void SetCameraFollowPosition(Vector3 targetPosition)
    {
        cinemachineFollowTransform.position = targetPosition;
    }

    public Grid<GridObject> GetGrid()
    {
        return grid;
    }

    public Tilemap GetTilemap()
    {
        return tilemap;
    }
    public Tilemap GetWalkableTilemap()
    {
        return walkableTilemap;
    }

    public class EmptyGridObject
    {
        private Grid<EmptyGridObject> grid;
        private int x;
        private int y;

        public EmptyGridObject(Grid<EmptyGridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
            
            Vector3 worldPos00 = grid.GetWorldPosition(x, y);
            Vector3 worldPos10 = grid.GetWorldPosition(x + 1, y);
            Vector3 worldPos01 = grid.GetWorldPosition(x, y + 1);
            Vector3 worldPos11 = grid.GetWorldPosition(x + 1, y + 1);

            Debug.DrawLine(worldPos00, worldPos01, Color.white, 999f);
            Debug.DrawLine(worldPos00, worldPos10, Color.white, 999f);
            Debug.DrawLine(worldPos01, worldPos11, Color.white, 999f);
            Debug.DrawLine(worldPos10, worldPos11, Color.white, 999f);
        }

        public override string ToString()
        {
            return "";
        }
    }
}
