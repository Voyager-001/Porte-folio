using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private Grid<HeatMapGenericGridObjct> grid;
    [SerializeField]private HeatMapGenericVisual heatMapGenericVisual;
    
    void Start()
    {
        grid = new Grid<HeatMapGenericGridObjct> (17,9, 10, Vector3.zero, (Grid<HeatMapGenericGridObjct> g, int x, int y) => new HeatMapGenericGridObjct(g,x,y));

        heatMapGenericVisual.SetGrid(grid);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HeatMapGenericGridObjct heatMapGridObjct = grid.GetGridObject(GetMousePosition.GetMouseWorldPosition());
            if(heatMapGridObjct != null)
            {
                heatMapGridObjct.AddValue(5);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetGridObject(GetMousePosition.GetMouseWorldPosition()));
        }
    }

    
}
