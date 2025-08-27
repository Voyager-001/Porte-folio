using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing4 : MonoBehaviour
{
    [SerializeField] private HeatMapIntVisual heatMapVisual;
    private Grid<int> grid;
    
    private void Start()
    {
        grid = new Grid<int>(17, 10, 10f, Vector3.zero, (Grid<int> g, int x, int y) => 0);

        heatMapVisual.SetGrid(grid);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = GetMousePosition.GetMouseWorldPosition();
            int value = grid.GetGridObject(mouseWorldPosition);
            grid.SetGridObject(mouseWorldPosition, value+5);
        }
    }
}
